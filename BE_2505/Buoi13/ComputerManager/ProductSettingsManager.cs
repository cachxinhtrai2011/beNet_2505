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
    public class ProductSettingsManager
    {
        public List<Product_Settings> product_Settings = new List<Product_Settings>();
        ComputerDBContext ComputerDBContext = new ComputerDBContext();
        Validate.ValidateData validateData = new Validate.ValidateData();
        public List<Product_Settings> GetListProductDetail()
        {
            var listProductSettings = new List<Product_Settings>();
            try
            {
                listProductSettings = ComputerDBContext.Product_Settings.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return listProductSettings;
        }
        public void AddProductDetail(Product_Settings product_Settings)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductSettingInput(product_Settings);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Product_Settings.Add(product_Settings);
                ComputerDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
        }
        public void DeleteProductDetail(Product_Settings product_Settings)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductSettingInput(product_Settings);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                var category = ComputerDBContext.Product_Settings
                                    .FirstOrDefault(c => c.ProductSettingID == product_Settings.ProductSettingID);

                if (category != null)
                {
                    // Bước 2: Sử dụng phương thức Remove để xóa đối tượng khỏi DbSet
                    ComputerDBContext.Product_Settings.Remove(product_Settings);

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
        public void UpdateProductDetail(Product_Settings product_Settings)
        {
            try
            {
                ReturnData returnData = validateData.ValidateProductSettingInput(product_Settings);
                if (returnData.ResponseCode != 1)
                {
                    Console.WriteLine(returnData.ResponseMessage);
                    Environment.Exit(1);
                }
                ComputerDBContext.Product_Settings.AddOrUpdate(product_Settings);
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
