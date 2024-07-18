using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace BE_2505.WebExercises.Models
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("name=BE2505_LuyenTap")
        { }
        public virtual DbSet<Product_Category> Product_Categorys { get; set; }
        public virtual DbSet<Product_Detail> Product_Details { get; set; }
    }
}
