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
    public class ProductGroupManager
    {
        public List<ProductGroup> ProductGroup = new List<ProductGroup>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
        Validate.ValidateData validateData = new Validate.ValidateData();
        public List<ProductGroup> GetListProductDetail()
        {
            var listProductSettings = new List<ProductGroup>();
            try
            {
                listProductSettings = ComputerDBContext.ProductGroups.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return listProductSettings;
        }
        public void AddProductDetail(ProductGroup ProductGroup)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductGroupInput(ProductGroup);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.ProductGroups.Add(ProductGroup);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void DeleteProductDetail(ProductGroup ProductGroup)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductGroupInput(ProductGroup);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                var category = ComputerDBContext.ProductGroups
                                    .FirstOrDefault(c => c.ProductGroupID == ProductGroup.ProductGroupID);

                if (category != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    ComputerDBContext.ProductGroups.Remove(ProductGroup);

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
        public void UpdateProductDetail(ProductGroup ProductGroup)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductGroupInput(ProductGroup);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.ProductGroups.AddOrUpdate(ProductGroup);
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
