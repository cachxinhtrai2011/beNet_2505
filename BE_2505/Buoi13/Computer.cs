using BE_2505.Buoi10;
using BE_2505.Buoi13.ClassDB;
using BE_2505.Buoi13.ComputerManager;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi13
{
    public class Computer
    {
        public void Menu()
        {
            ProductCategoryManager productCategoryManager = new ProductCategoryManager();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ MÁY TÍNH ----");
                Console.WriteLine("1. Thêm thông tin loại sản phẩm.");
                Console.WriteLine("2. Sửa thông tin loại sản phẩm.");
                Console.WriteLine("3. Xóa thông tin loại sản phẩm.");
                Console.WriteLine("4. Thêm thông tin sản phẩm.");
                Console.WriteLine("5. Sửa thông tin sản phẩm.");
                Console.WriteLine("6. Xóa thông tin sản phẩm.");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");
                int luachon = int.Parse(Console.ReadLine());
                switch (luachon)
                {
                    case 1:
                        Product_Category product_Category = new Product_Category();
                        product_Category.CategoryName = "test";
                        productCategoryManager.AddProductCategory(product_Category);
                        break;
                    case 2:
                        Product_Category product_CategoryUpdate = new Product_Category();
                        product_CategoryUpdate.CategoryID = 1;
                        product_CategoryUpdate.CategoryName = "Thuan";
                        product_CategoryUpdate.IsActive = true;
                        productCategoryManager.UpdateProductCategory(product_CategoryUpdate);
                        break;
                    case 3:
                        Product_Category product_CategoryDelete = new Product_Category();
                        product_CategoryDelete.CategoryID = 1;
                        product_CategoryDelete.CategoryName = "Thuan";
                        product_CategoryDelete.IsActive = true;
                        productCategoryManager.DeleteProductCategory(product_CategoryDelete);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
