using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOnFinger_API.Models
{
    public class ProductView : DbContext
    {
        public ProductView(DbContextOptions<ProductView> options) : base(options)
            {

            }

            public DbSet<Cuisine> Cuisine { get; set; }
        }
}
