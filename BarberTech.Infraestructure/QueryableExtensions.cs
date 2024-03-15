using BarberTech.Domain.Entities;
using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Reflection;

namespace BarberTech.Infraestructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> query, int page, int pageSize)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, string? searchTerm, string[] props)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || !props.Any())
            {
                return query;
            }

            var entityType = typeof(TEntity);
            var parameter = Expression.Parameter(entityType, "x");
            var expressions = new List<Expression>();
            
            FillExpressions(expressions, entityType, parameter, props, searchTerm);

            var body = expressions.Any() ? expressions.Aggregate(Expression.OrElse) : Expression.Constant(false);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return query.Where(lambda);
        }

        private static List<Expression> FillExpressions(
            List<Expression> expressions, Type entityType, Expression parameter, IEnumerable<string> props, string searchTerm)
        {
            foreach (var propertyName in props)
            {
                var property = entityType.GetProperty(propertyName);

                if (property == null) { continue; }

                var propertyAccess = Expression.Property(parameter, property);
                var searchTermExpression = Expression.Constant(searchTerm.ToLower(), typeof(string));

                if (property.PropertyType == typeof(string))
                {
                    var toLowerCall = Expression.Call(propertyAccess, "ToLower", null);
                    var containsCall = Expression.Call(toLowerCall, "Contains", null, searchTermExpression);
                    expressions.Add(containsCall);
                    continue;
                }
                if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(int))
                {
                    var parsedTerm = TryParse(searchTerm, property.PropertyType);

                    if (parsedTerm is null) { continue; }

                    var containsCall = Expression.Call(propertyAccess, "Equals", null, parsedTerm);
                    expressions.Add(containsCall);
                    continue;
                }
                if (property.PropertyType.BaseType == typeof(Entity))
                {
                    var filteredProps = props.Where(p => p != propertyName);
                    var nestedEntityType = property.PropertyType;
                    FillExpressions(expressions, nestedEntityType, propertyAccess, filteredProps, searchTerm);
                }
            }
            return expressions;
        }

        private static Expression? TryParse(string searchTerm, Type type)
        {
            if (type == typeof(decimal))
            {
                var success = decimal.TryParse(searchTerm, out var converted);
                return success ? Expression.Constant(converted, typeof(decimal)) : null;
            }
            if (type == typeof(int))
            {
                var success = int.TryParse(searchTerm, out var converted);
                return success ? Expression.Constant(converted, typeof(int)) : null;
            }
            return null;
        }
    }
}
