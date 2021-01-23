using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }
    }
}