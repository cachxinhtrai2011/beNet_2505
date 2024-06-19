using BE_2505.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi7.Bai2
{
    public abstract class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public float GiaBan { get; set; }
        public abstract void TinhGiaBanSanPham();
        public void NhapThongTinSanPham()
        {
            Console.Write("Nhập mã sản phẩm: ");
            MaSanPham = Console.ReadLine();
            Console.Write("Nhập tên sản phẩm: ");
            TenSanPham = Console.ReadLine();
            Console.Write("Nhập giá bán: ");
            GiaBan = float.Parse(Console.ReadLine());
        }
        public void XuatThongTinSanPham()
        {
            Console.Write($"Mã sản phẩm: {MaSanPham}");
            Console.Write($"Tên sản phẩm: {TenSanPham}");
            Console.Write($"Giá bán: {GiaBan}");
        }
    }
}
