using BE_2505.Buoi13.ClassDB;
using BE_2505.Buoi13.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi13.ComputerManager
{
    public class ProductDetailManager
    {
        public List<Product_Detail> Product_Details = new List<Product_Detail>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
    }
}
