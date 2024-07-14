using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi14.ClassDB
{
    public class ProductGroupPrice
    {
        [Key]
        public long ProductGroupID { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDateTime { get; set; }
        public string DeletedUser { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string UpatedUser { get; set; }
    }
}
