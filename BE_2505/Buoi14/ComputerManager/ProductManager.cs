using BE_2505.Buoi14.DBContext;
using BE_2505.Buoi14.ClassDB;
using BE_2505.Common.Validate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi14.ComputerManager
{
    public class ProductManager
    {
        public List<Product> Products = new List<Product>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
        Validate.ValidateData validateData = new Validate.ValidateData();
        public List<Product> GetListProductDetail()
        {
            var listProductDetail = new List<Product>();
            try
            {
                listProductDetail = ComputerDBContext.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return listProductDetail;
        }
        public void AddProductDetail(Product Product)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductInput(Product);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Products.Add(Product);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void DeleteProductDetail(Product Product)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductInput(Product);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                var category = ComputerDBContext.Products
                                    .FirstOrDefault(c => c.ProductID == Product.ProductID);

                if (category != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    ComputerDBContext.Products.Remove(category);

                    // Bước 3: Gọi phương thức SaveChanges để lưu các thay đổi
                    ComputerDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void UpdateProductDetail(Product Product)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductInput(Product);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Products.AddOrUpdate(Product);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
    }
}
