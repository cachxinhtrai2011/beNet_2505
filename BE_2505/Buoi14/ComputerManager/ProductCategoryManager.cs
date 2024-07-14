using BE_2505.Buoi14.ClassDB;
using BE_2505.Buoi14.DBContext;
using BE_2505.Common.Validate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi14.ComputerManager
{
    public class ProductCategoryManager
    {
        public List<ProductCategory> product_Categories = new List<ProductCategory>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
        Validate.ValidateData validateData = new Validate.ValidateData();
        public List<ProductCategory> GetListProductCategory()
        {
            var listProductCategory = new List<ProductCategory>();
            try
            {
                listProductCategory = ComputerDBContext.ProductCategories.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return listProductCategory;
        }
        public void AddProductCategory(ProductCategory ProductCategory)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductCategoryInput(ProductCategory);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.ProductCategories.Add(ProductCategory);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void DeleteProductCategory(ProductCategory ProductCategory)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductCategoryInput(ProductCategory);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                var category = ComputerDBContext.ProductCategories
                                    .FirstOrDefault(c => c.CategoryID == ProductCategory.CategoryID);

                if (category != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    ComputerDBContext.ProductCategories.Remove(category);

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
        public void UpdateProductCategory(ProductCategory ProductCategory)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductCategoryInput(ProductCategory);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.ProductCategories.AddOrUpdate(ProductCategory);
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
