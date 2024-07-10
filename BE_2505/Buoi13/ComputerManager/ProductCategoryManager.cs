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
    public class ProductCategoryManager
    {
        public List<Product_Category> product_Categories = new List<Product_Category>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
        Validate.ValidateData validateData = new Validate.ValidateData();
        public List<Product_Category> GetListProductCategory()
        {
            var listProductCategory = new List<Product_Category>();
            try
            {
                listProductCategory = ComputerDBContext.Product_Categorys.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return listProductCategory;
        }
        public void AddProductCategory(Product_Category product_Category)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductCategoryInput(product_Category);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Product_Categorys.Add(product_Category);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void DeleteProductCategory(Product_Category product_Category)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductCategoryInput(product_Category);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                var category = ComputerDBContext.Product_Categorys
                                    .FirstOrDefault(c => c.CategoryID == product_Category.CategoryID);

                if (category != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    ComputerDBContext.Product_Categorys.Remove(category);

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
        public void UpdateProductCategory(Product_Category product_Category)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductCategoryInput(product_Category);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Product_Categorys.AddOrUpdate(product_Category);
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
