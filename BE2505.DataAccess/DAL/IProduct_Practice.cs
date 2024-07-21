using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.Common.Validate;
using BE2505.DataAccess.DTO;

namespace BE2505.DataAccess.DAL
{
    public interface IProduct_Practice
    {
        ReturnData Product_Insert(Product_Practice product_Practice);
        ReturnData Product_Update(Product_Practice product_Practice);
        ReturnData Product_Delete(Product_Practice product_Practice);
        List<Product_Practice> GetListProduct();
    }
}
