using System.Collections.Generic;

namespace NultienShop.Common.ViewModels
{
    public class PaginationResponse<T>
    {
        public PaginationResponse(List<T> list, long total)
        {
            Results = list?.Count > 0 ? list : new List<T>();
            Total = total;
        }

        public List<T> Results { get; }
        public long Total { get; }
    }

    public class Pagination
    {
        public Pagination(int page, int size)
        {
            PageNumber = page;
            PageSize = size;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}