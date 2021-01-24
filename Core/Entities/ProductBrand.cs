using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProductBrand:BaseEntity
    {
        [Required, StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }
    }
}