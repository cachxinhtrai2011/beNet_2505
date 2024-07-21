using BE_2505.Common.Validate;
using BE2505.DataAccess.DAL;
using BE2505.DataAccess.DTO;
using BE2505.DataAccess.Validate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2505.DataAccess.DALImplement
{
    public class ProductManager : IProduct_Practice
    {
        ProductDbContext productDbContext = new ProductDbContext();
        ValidateData_Product validateData_Product = new ValidateData_Product();
        public List<Product_Practice> GetListProduct()
        {
            var result = new List<Product_Practice>();
            try
            {
                result = productDbContext.Product_Practices.ToList();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return result;
        }

        public ReturnData Product_Delete(Product_Practice product_Practice)
        {
            ReturnData returnDataDelete = new ReturnData();
            try
            {
                var product = productDbContext.Product_Practices
                                    .FirstOrDefault(c => c.ProductID == product_Practice.ProductID);

                if (product != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    productDbContext.Product_Practices.Remove(product);

                    // Bước 3: Gọi phương thức SaveChanges để lưu các thay đổi
                    productDbContext.SaveChanges();
                    returnDataDelete.ResponseCode = 1;
                    returnDataDelete.ResponseMessage = "Xóa thành công nè";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return returnDataDelete;
        }

        public ReturnData Product_Insert(Product_Practice product_Practice)
        {
            ReturnData returnDataInsert = new ReturnData();
            try
            {
                //Kiểm tra đầu vào
                ReturnData returnData = validateData_Product.ValidateProductInput(product_Practice);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                productDbContext.Product_Practices.Add(product_Practice);
                productDbContext.SaveChanges();
                returnDataInsert.ResponseCode = 1;
                returnDataInsert.ResponseMessage = "Insert thành công";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return returnDataInsert;
        }

        public ReturnData Product_Update(Product_Practice product_Practice)
        {
            ReturnData returnDataUpdate = new ReturnData();
            try
            {
                //Kiểm tra đầu vào
                ReturnData returnData = validateData_Product.ValidateProductInput(product_Practice);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                productDbContext.Product_Practices.AddOrUpdate(product_Practice);
                productDbContext.SaveChanges();
                returnDataUpdate.ResponseCode = 1;
                returnDataUpdate.ResponseMessage = "Update thành công";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return returnDataUpdate;
        }
    }
}
