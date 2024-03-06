using System.Linq.Expressions;

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

            var body = props
                .Select(entityType.GetProperty)
                .Where(property => property != null)
                .Select(property => Expression.Call(
                    Expression.Property(parameter, property),
                    "Contains",
                    null,
                    Expression.Constant(searchTerm, typeof(string))
                ))
                .Aggregate<Expression>(Expression.OrElse);

            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
            return query.Where(lambda);
        }
    }
}
