namespace BILLSToPAY.Domain.Shared.Models
{
    public class Filter
    {
        public string Search { get; set; }
        public int? TotalItems { get; set; }
        public int? CurrentPage { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
