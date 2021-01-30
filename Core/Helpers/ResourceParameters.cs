
namespace Core.Helpers
{
    public class ResourceParameters
    {
        public string OrderBy { get; set; } = "name";
        public string OrderByDescending { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }
        public string Search { get; set; }

        public int PageNumber { get; set; } = 1;
        private const int MaxPageSize = 20;
        private int _defaultPageSize = 10;

        public int PageSize
        {
            get => _defaultPageSize;
            set => _defaultPageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
