namespace SmartHintDev.Domain.Core.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int page, int pageSize)
        {
            if (page <= 0) page = 1;

            if (pageSize <= 0) pageSize = 10;

            var data = query.Skip((page - 1) * pageSize).Take(pageSize);
            return data;
        }
    }
}
