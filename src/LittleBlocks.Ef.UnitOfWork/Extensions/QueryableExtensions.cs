namespace LittleBlocks.Ef.UnitOfWork.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> PagedBy<T>(this IQueryable<T> queryable, PagingOptions options)
        {
            ArgumentNullException.ThrowIfNull(queryable);
            ArgumentNullException.ThrowIfNull(options);

            return queryable.PagedBy(options.PageIndex, options.PageSize);
        }

        public static IQueryable<T> PagedBy<T>(this IQueryable<T> queryable, int pageIndex, int pageSize)
        {
            ArgumentNullException.ThrowIfNull(queryable);
            ArgumentOutOfRangeException.ThrowIfNegative(pageIndex);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageSize);

            return queryable.Skip(pageIndex * pageSize).Take(pageSize);
        }        
        
        public static IQueryable<TResult> ProjectTo<T, TResult>(this IQueryable<T> queryable, Func<T, TResult> projection)
        {
            ArgumentNullException.ThrowIfNull(queryable);
            ArgumentNullException.ThrowIfNull(projection);

            return queryable.Select(m => projection(m));
        }
    }
}