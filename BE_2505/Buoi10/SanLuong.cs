using BE_2505.Buoi10.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE_2505.Buoi10
{
    public class SanLuong : ISanLuong
    {
        public string MaCongDoan { get; set; }
        public string TenCongDoan { set; get; }
        public int SoLuongSanPham { get; set; }
        public float GiaSanPham {  set; get; }

        public void NhapSanLuong()
        {
            BE_2505.Common.ValidateData _ValidateData = new BE_2505.Common.ValidateData();
            Console.Write("Nhập mã công đoạn: ");
            MaCongDoan = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(MaCongDoan))
            {
                Console.WriteLine("Định dạng MCĐ không đúng!");
                Environment.Exit(1);
            }
            Console.Write("Nhập tên công đoạn: ");
            TenCongDoan = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(TenCongDoan))
            {
                Console.WriteLine("Định dạng TCĐ không đúng!");
                Environment.Exit(1);
            }
            //Kiểm tra đầu vào số lượng sp
            Console.Write("Nhập số lượng sản phẩm: ");
            string SlSanPham_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(SlSanPham_Temp))
            {
                Console.WriteLine("Định dạng SL không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(SlSanPham_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            SoLuongSanPham = int.Parse(SlSanPham_Temp);

            //Kiểm tra đầu vào giá sp
            Console.Write("Nhập giá sản phẩm: ");
            string GiaSanPham_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(GiaSanPham_Temp))
            {
                Console.WriteLine("Định dạng GSP không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(GiaSanPham_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            GiaSanPham = float.Parse(GiaSanPham_Temp);
        }
        public void XuatSanLuong()
        {
            Console.WriteLine($"Mã công đoàn: {MaCongDoan}");
            Console.WriteLine($"Tên công đoàn: {TenCongDoan}");
            Console.WriteLine($"Số lượng sản phẩm: {SoLuongSanPham}");
            Console.WriteLine($"Giá sản phẩm: {GiaSanPham}");
        }
        public float TinhGiaSanPham()
        {
            return GiaSanPham * SoLuongSanPham;
        }
    }
}
