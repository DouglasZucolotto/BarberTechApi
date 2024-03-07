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

            foreach (var propertyName in props)
            {
                var property = entityType.GetProperty(propertyName);

                if (property == null) { continue; }

                var propertyAccess = Expression.Property(parameter, property);
                CallByType(property, propertyAccess, expressions, searchTerm);

                if (property.PropertyType.BaseType == typeof(Entity))
                {
                    var nestedProperties = property.PropertyType.GetProperties()
                        .Where(p => props.Any(prop => prop == p.Name) && p.PropertyType == typeof(string));

                    foreach (var nestedProperty in nestedProperties)
                    {
                        var nestedPropertyAccess = Expression.Property(propertyAccess, nestedProperty);
                        CallByType(nestedProperty, nestedPropertyAccess, expressions, searchTerm);
                    }
                }
            }

            var body = expressions.Any() ? expressions.Aggregate(Expression.OrElse) : Expression.Constant(false);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return query.Where(lambda);
        }
        
        private static void CallByType(
            PropertyInfo property, MemberExpression propertyAccess, List<Expression> expressions, string searchTerm)
        {
            var searchTermExpression = Expression.Constant(searchTerm, typeof(string));

            if (property.PropertyType == typeof(string))
            {
                var containsCall = Expression.Call(propertyAccess, "Contains", null, searchTermExpression);
                expressions.Add(containsCall);
                return;
            } 
            if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(int))
            {
                var parsedTerm = TryParse(searchTerm, property.PropertyType);

                if (parsedTerm is null) { return; }

                var containsCall = Expression.Call(propertyAccess, "Equals", null, parsedTerm);
                expressions.Add(containsCall);
                return;
            }
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
