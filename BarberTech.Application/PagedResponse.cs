using Microsoft.EntityFrameworkCore;

namespace BarberTech.Application
{
    public class PagedResponse<T>
    {
        public PagedResponse(IEnumerable<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public IEnumerable<T> Items { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasNextPage => Page * PageSize < TotalCount;

        public bool HasPreviousPage => Page > 1;
    }
}
