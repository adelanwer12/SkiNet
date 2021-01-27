using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product: BaseEntity
    {
        [Required, StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [Required, StringLength(500,MinimumLength = 4)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required, StringLength(50,MinimumLength = 4)]
        public string PictureUrl { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        public Guid ProductTypeId { get; set; }

        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrand { get; set; }
        
        public Guid ProductBrandId { get; set; }
    }
}