using BE_2505.Buoi13.ClassDB;
using BE_2505.Buoi13.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi13.ComputerManager
{
    public class ProductSettingsManager
    {
        public List<Product_Settings> product_Settings = new List<Product_Settings>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
    }
}
