namespace BankApp.Core.Repositories.Pagination
{
    public class PaginationRequest
    {
        private int _pageSize = 10;
        private int _pageIndex = 1;
        private const int MaxPageSize = 50;
        private const int MinPageSize = 1;
        private const int MinPageIndex = 1;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value < MinPageIndex ? MinPageIndex : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value < MinPageSize ? MinPageSize : value;
        }

        public int Skip => (PageIndex - 1) * PageSize;
        public int Take => PageSize;
    }
} 