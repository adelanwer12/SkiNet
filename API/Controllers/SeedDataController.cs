using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/seeddata")]
    public class SeedDataController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly UserManager<AppUser> _userManager;

        public SeedDataController(StoreContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("brands")]
        public async Task<ActionResult> PostBrands()
        {
            if (!await _context.productBrands.AnyAsync())
            {
                var brands = new[]
                {
                    new ProductBrand()
                    {
                        Id = Guid.Parse("3246ACD8-7434-4137-43C1-08D8C6BB4B34"),
                        Name = "Angular"
                    },
                    new ProductBrand()
                    {
                        Id = Guid.Parse("017C7456-699E-46B9-43C2-08D8C6BB4B34"),
                        Name = "NetCore"
                    },
                    new ProductBrand()
                    {
                        Id = Guid.Parse("1125C2CA-AAEE-4F09-43C3-08D8C6BB4B34"),
                        Name = "VS Code"
                    },
                    new ProductBrand()
                    {
                        Id = Guid.Parse("65087E48-DD55-4EAC-43C4-08D8C6BB4B34"),
                        Name = "React"
                    },
                    new ProductBrand()
                    {
                        Id = Guid.Parse("42DB16B2-343B-4E1C-43C5-08D8C6BB4B34"),
                        Name = "Typescript"
                    },
                    new ProductBrand()
                    {
                        Id = Guid.Parse("19BE46AB-1058-4A9F-43C6-08D8C6BB4B34"),
                        Name = "Redis"
                    }
                };

                foreach (var brand in brands)
                {
                    await _context.productBrands.AddAsync(brand);
                }

                var result = await _context.SaveChangesAsync();
                if (result >= 0)
                {
                    return Ok("Brands Add");
                }

                return BadRequest("Error in saving data please check your connection to database");
            }

            return BadRequest("there is already products brands in database");
        }

        [HttpPost("types")]
        public async Task<ActionResult> PostTypes()
        {
           
            if (!await _context.productTypes.AnyAsync())
            {
                var types = new[]
                {
                    new ProductType()
                    {
                        Id = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        Name = "Boards"
                    },
                    new ProductType()
                    {
                        Id = Guid.Parse("4C0C0276-1DCE-4750-39A0-08D8C6BB9138"),
                        Name = "Hats"
                    },
                    new ProductType()
                    {
                        Id = Guid.Parse("7C24EDB7-89D1-46BA-39A1-08D8C6BB9138"),
                        Name = "Boots"
                    },
                    new ProductType()
                    {
                        Id = Guid.Parse("929E3E75-46EC-43B9-39A2-08D8C6BB9138"),
                        Name = "Gloves"
                    }
                };

                foreach (var type in types)
                {
                    await _context.productTypes.AddAsync(type);
                }

                var result = await _context.SaveChangesAsync();
                if (result >= 0)
                {
                    return Ok("types Add");
                }

                return BadRequest("Error in saving data please check your connection to database");
            }

            return BadRequest("there is already products types in database");
        }

        [HttpPost("product")]
        public async Task<IActionResult> PostProducts()
        {
            if (!await _context.productBrands.AnyAsync() || !await _context.productTypes.AnyAsync())
            {
                return BadRequest("you must add products bands and products types first");
            }
            if (!await _context.Products.AnyAsync())
            {
                var products = new[]
                {
                    new Product()
                    {
                        Name = "Angular Speedster Board 2000",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 200,
                        PictureUrl = "images/products/sb-ang1.png",
                        ProductTypeId = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("3246ACD8-7434-4137-43C1-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Green Angular Board 3000",
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 150,
                        PictureUrl = "images/products/sb-ang2.png",
                        ProductTypeId = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("3246ACD8-7434-4137-43C1-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Core Board Speed Rush 3",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 180,
                        PictureUrl = "images/products/sb-core1.png",
                        ProductTypeId = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("017C7456-699E-46B9-43C2-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Net Core Super Board",
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 300,
                        PictureUrl = "images/products/sb-core2.png",
                        ProductTypeId = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("017C7456-699E-46B9-43C2-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "React Board Super Whizzy Fast",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 250,
                        PictureUrl = "images/products/sb-react1.png",
                        ProductTypeId = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("65087E48-DD55-4EAC-43C4-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Typescript Entry Board",
                        Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        Price = 120,
                        PictureUrl = "images/products/sb-ts1.png",
                        ProductTypeId = Guid.Parse("CDFDE3FC-B4B5-467F-399F-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("42DB16B2-343B-4E1C-43C5-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Core Blue Hat",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 10,
                        PictureUrl = "images/products/hat-core1.png",
                        ProductTypeId = Guid.Parse("4C0C0276-1DCE-4750-39A0-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("017C7456-699E-46B9-43C2-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Green React Woolen Hat",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 8,
                        PictureUrl = "images/products/hat-react1.png",
                        ProductTypeId = Guid.Parse("4C0C0276-1DCE-4750-39A0-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("65087E48-DD55-4EAC-43C4-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Purple React Woolen Hat",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 15,
                        PictureUrl = "images/products/hat-react2.png",
                        ProductTypeId = Guid.Parse("4C0C0276-1DCE-4750-39A0-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("65087E48-DD55-4EAC-43C4-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Blue Code Gloves",
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 18,
                        PictureUrl = "images/products/glove-code1.png",
                        ProductTypeId = Guid.Parse("929E3E75-46EC-43B9-39A2-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("1125C2CA-AAEE-4F09-43C3-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Green Code Gloves",
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 15,
                        PictureUrl = "images/products/glove-code2.png",
                        ProductTypeId = Guid.Parse("929E3E75-46EC-43B9-39A2-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("1125C2CA-AAEE-4F09-43C3-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Purple React Gloves",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                        Price = 16,
                        PictureUrl = "images/products/glove-react1.png",
                        ProductTypeId = Guid.Parse("929E3E75-46EC-43B9-39A2-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("65087E48-DD55-4EAC-43C4-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Green React Gloves",
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 14,
                        PictureUrl = "images/products/glove-react2.png",
                        ProductTypeId = Guid.Parse("929E3E75-46EC-43B9-39A2-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("65087E48-DD55-4EAC-43C4-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Redis Red Boots",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 250,
                        PictureUrl = "images/products/boot-redis1.png",
                        ProductTypeId = Guid.Parse("7C24EDB7-89D1-46BA-39A1-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("19BE46AB-1058-4A9F-43C6-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Core Red Boots",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 189.99,
                        PictureUrl = "images/products/boot-core2.png",
                        ProductTypeId = Guid.Parse("7C24EDB7-89D1-46BA-39A1-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("017C7456-699E-46B9-43C2-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Core Purple Boots",
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 199.99,
                        PictureUrl = "images/products/boot-core1.png",
                        ProductTypeId = Guid.Parse("7C24EDB7-89D1-46BA-39A1-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("017C7456-699E-46B9-43C2-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Angular Purple Boots",
                        Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        Price = 150,
                        PictureUrl = "images/products/boot-ang2.png",
                        ProductTypeId = Guid.Parse("7C24EDB7-89D1-46BA-39A1-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("3246ACD8-7434-4137-43C1-08D8C6BB4B34")
                    },
                    new Product()
                    {
                        Name = "Angular Blue Boots",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 180,
                        PictureUrl = "images/products/boot-ang1.png",
                        ProductTypeId = Guid.Parse("7C24EDB7-89D1-46BA-39A1-08D8C6BB9138"),
                        ProductBrandId = Guid.Parse("3246ACD8-7434-4137-43C1-08D8C6BB4B34")
                    }
                };
                foreach (var product in products)
                {
                    await _context.Products.AddAsync(product);
                }

                var result = await _context.SaveChangesAsync();
                if (result >= 0)
                {
                    return Ok("Brands Add");
                }

                return BadRequest("Error in saving data please check your connection to database");
            }

            return BadRequest("there is already products in database");
        }

        [HttpPost("users")]
        public async Task<ActionResult> PostUsers()
        {
            if (!_userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new()
                    {
                        DisplayName = "Adel",
                        Email = "adel@adel.com",
                        UserName = "adel@adel.com",
                        Address = new List<Address>
                        {
                            new()
                            {
                                FirstName = "Adel",
                                LastName = "Ibrahim",
                                Street = "Dolkam",
                                City = "Samalout",
                                State = "El Menia",
                                ZipCode = "61661"
                            },
                            new()
                            {
                                FirstName = "Adel",
                                LastName = "Ibrahim",
                                Street = "Saad Zakhlol",
                                City = "Samalout",
                                State = "El Menia",
                                ZipCode = "61661"
                            }
                        }
                    },
                    new()
                    {
                        DisplayName = "felo",
                        Email = "felo@adel.com",
                        UserName = "felo@adel.com",
                        Address = new List<Address>
                        {
                            new()
                            {
                                FirstName = "felo",
                                LastName = "Ibrahim",
                                Street = "mankateen",
                                City = "Samalout",
                                State = "El Menia",
                                ZipCode = "61661"
                            },
                            new()
                            {
                                FirstName = "felo",
                                LastName = "Ibrahim",
                                Street = "shark",
                                City = "Samalout",
                                State = "El Menia",
                                ZipCode = "61661"
                            }
                        }
                    }
                };
                foreach (var user in users)
                {
                    var result = await _userManager.CreateAsync(user, "Pa$$w0rd");
                    if (!result.Succeeded)
                    {
                        return BadRequest(result.Errors);
                    }
                }

                return Ok("users add");
            }

            return BadRequest("there is users");
        }
    }
}