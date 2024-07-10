using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi13.ClassDB
{
    public class Product_Settings
    {
        public int ProductSettingID { get; set; }
        public int ProductID { get; set; }
        public decimal RAM { get; set; }
        public string RAMUnit { get; set; }
        public string Core { get; set; }
        public decimal ScreenWidth { get; set; }
        public string ScreenUnit { get; set; }
    }
}
