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
        public NhanVien nhanVien { set; get; }

        public void NhapSanLuong()
        {
            Console.Write("Nhập mã công đoạn: ");
            MaCongDoan = Console.ReadLine();
            Console.Write("Nhập tên công đoạn: ");
            TenCongDoan = Console.ReadLine();
            Console.Write("Nhập số lượng sản phẩm: ");
            SoLuongSanPham = int.Parse(Console.ReadLine());
            Console.Write("Nhập giá sản phẩm: ");
            GiaSanPham = float.Parse(Console.ReadLine());
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
        public void XuatBaoCaoSanLuong()
        {
            throw new NotImplementedException();
        }
    }
}
