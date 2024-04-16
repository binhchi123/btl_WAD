using Btl.Areas.Admin.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Btl.Areas.Admin.Models.BusinessModels
{
    public class BamaContext : DbContext
    {
        public BamaContext()
        {

        }
        public BamaContext(DbContextOptions<BamaContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public object Category { get; internal set; }
    }
}
