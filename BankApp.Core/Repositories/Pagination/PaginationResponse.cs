namespace BankApp.Core.Repositories.Pagination
{
    public class PaginationResponse<T>
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public IList<T> Items { get; }
        public int FirstItemIndex => (PageIndex - 1) * PageSize + 1;
        public int LastItemIndex => Math.Min(PageIndex * PageSize, TotalCount);
        public bool IsFirstPage => PageIndex == 1;
        public bool IsLastPage => PageIndex == TotalPages;

        public PaginationResponse(IList<T> items, int pageIndex, int pageSize, int totalCount)
        {
            if (pageIndex < 1)
                throw new ArgumentException("Page index must be greater than or equal to 1.", nameof(pageIndex));
            if (pageSize < 1)
                throw new ArgumentException("Page size must be greater than or equal to 1.", nameof(pageSize));
            if (totalCount < 0)
                throw new ArgumentException("Total count cannot be negative.", nameof(totalCount));

            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public static PaginationResponse<T> Empty(int pageSize = 10)
        {
            return new PaginationResponse<T>(new List<T>(), 1, pageSize, 0);
        }
    }
} 