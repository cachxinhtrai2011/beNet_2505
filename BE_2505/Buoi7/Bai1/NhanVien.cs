using BE_2505.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE_2505.Buoi7.Bai1
{
    public abstract class NhanVien
    {
        BE_2505.Common.ValidateData _ValidateData = new BE_2505.Common.ValidateData();
        string MaNhanVien { get; set; }
        string TenNhanVien { get; set; }
        public abstract void TinhLuongNhanVien();
        public void NhapThongTinNhanVien()
        {

            Console.Write("Nhập mã nhân viên: ");
            MaNhanVien = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(MaNhanVien))
            {
                Console.WriteLine("Định dạng MaNhanVien không đúng!");
                Environment.Exit(1);
            }
            Console.Write("Nhập tên nhân viên: ");
            TenNhanVien = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(TenNhanVien))
            {
                Console.WriteLine("Định dạng TenNhanVien không đúng!");
                Environment.Exit(1);
            }
        }
        public void XuatThongTinNhanVien()
        {
            Console.WriteLine($"Mã nhân viên: {MaNhanVien}");
            Console.WriteLine($"Tên nhân viên: {TenNhanVien}");
        }
    }
}
