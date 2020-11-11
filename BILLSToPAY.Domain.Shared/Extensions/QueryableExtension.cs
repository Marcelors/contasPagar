using System;
using System.Linq;

namespace BILLSToPAY.Domain.Shared.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int? page, int? itensPerPage)
        {
            if (!page.HasValue && !itensPerPage.HasValue)
            {
                return query;
            }
            if (!itensPerPage.HasValue)
            {
                return query;
            }
            if (!page.HasValue)
            {
                return query.Take(itensPerPage.Value);
            }

            var skip = (page - 1) * itensPerPage;

            return query.Skip(skip.Value).Take(itensPerPage.Value);
        }
    }
}
