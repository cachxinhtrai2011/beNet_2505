using BE_2505.Buoi13.ClassDB;
using BE_2505.Buoi13.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi13.ComputerManager
{
    public class ProductCategoryManager
    {
        public List<Product_Category> product_Categories = new List<Product_Category>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
    }
}
