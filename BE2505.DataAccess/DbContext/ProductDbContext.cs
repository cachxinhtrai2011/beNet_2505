using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE2505.DataAccess.DTO;

namespace BE2505.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("name=BE2505_LuyenTap") { }
        public virtual DbSet<Product_Practice> Product_Practices { get; set; }
    }
}
