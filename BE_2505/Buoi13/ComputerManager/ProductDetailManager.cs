using BE_2505.Buoi13.ClassDB;
using BE_2505.Buoi13.DBContext;
using BE_2505.Common.Validate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi13.ComputerManager
{
    public class ProductDetailManager
    {
        public List<Product_Detail> Product_Details = new List<Product_Detail>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
        Validate.ValidateData validateData = new Validate.ValidateData();
        public List<Product_Detail> GetListProductDetail()
        {
            var listProductDetail = new List<Product_Detail>();
            try
            {
                listProductDetail = ComputerDBContext.Product_Details.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return listProductDetail;
        }
        public void AddProductDetail(Product_Detail product_Detail)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductDetailInput(product_Detail);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Product_Details.Add(product_Detail);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void DeleteProductDetail(Product_Detail product_Detail)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductDetailInput(product_Detail);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                var category = ComputerDBContext.Product_Details
                                    .FirstOrDefault(c => c.ProductID == product_Detail.ProductID);

                if (category != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    ComputerDBContext.Product_Details.Remove(category);

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
        public void UpdateProductDetail(Product_Detail product_Detail)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductDetailInput(product_Detail);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Product_Details.AddOrUpdate(product_Detail);
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
