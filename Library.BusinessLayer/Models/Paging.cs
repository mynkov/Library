namespace Library.BusinessLayer.Models
{
    public class Paging
    {
        public Paging(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
