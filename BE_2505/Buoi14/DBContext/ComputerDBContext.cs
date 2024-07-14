using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using BE_2505.Buoi14.ClassDB;

namespace BE_2505.Buoi14.DBContext
{
    public class ComputerDBContext : DbContext
    {
        public ComputerDBContext() : base("name=Computer")
        { }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductAttributeDetail> ProductAttributeDetails { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductGroupAttribute> ProductGroupAttributes { get; set; }
        public virtual DbSet<ProductGroupAttributeDetail> ProductGroupAttributeDetails { get; set; }
        public virtual DbSet<ProductGroupPrice> ProductGroupPrices { get; set; }
    }
}
