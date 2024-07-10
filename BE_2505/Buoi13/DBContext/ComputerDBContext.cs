using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using BE_2505.Buoi13.ClassDB;

namespace BE_2505.Buoi13.DBContext
{
    public class ComputerDBContext : DbContext
    {
        public ComputerDBContext() : base("name=Computer")
        { }
        public virtual DbSet<Product_Category> Product_Categorys { get; set; }
        public virtual DbSet<Product_Detail> Product_Details { get; set; }
        public virtual DbSet<Product_Settings> Product_Settings { get; set; }
    }
}
