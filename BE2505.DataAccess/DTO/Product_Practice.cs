using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BE2505.DataAccess.DTO
{
    public class Product_Practice
    {
        [Key]
        public int ProductID { get; set; }
        public string PracticeName { get; set; }
        public string PracticeDesc { get; set; }
        public bool IsActive { get; set; }
    }
}
