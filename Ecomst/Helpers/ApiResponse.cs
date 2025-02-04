using Ecomst.Entities;

namespace Ecomst.Helpers
{
    public class ApiResponse
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<ApplicationUser> Data { get; set; }
    }
}
