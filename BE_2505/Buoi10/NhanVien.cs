using BE_2505.Buoi10.Interface;
using BE_2505.Buoi7.Bai3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi10
{
    public class NhanVien : INhanVien
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public float LuongCoBan { get; set; }
        public float HeSoLuong { get; set; }
        public float PhuCap { get; set; }
        public float TongLuong { get; set; }

        public void ThemNhanVien()
        {
            Console.Write("Nhập tên Nhân viên: ");
            Name = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhập lương cơ bản: ");
            LuongCoBan = float.Parse(Console.ReadLine());
            Console.Write("Nhập hệ số lương: ");
            HeSoLuong = float.Parse(Console.ReadLine());
            Console.Write("Nhập Phụ cấp: ");
            PhuCap = float.Parse(Console.ReadLine());
            Console.Write("Nhập tổng số lương: ");
            TongLuong = float.Parse(Console.ReadLine());
        }
        public void XuatThongTinNhanVien()
        {
            Console.WriteLine($"Tên: {Name}");
            Console.WriteLine($"Giới tính: {GioiTinh}");
            Console.WriteLine($"Tuổi: {Tuoi}");
            Console.WriteLine($"Lương cơ bản: {LuongCoBan}");
            Console.WriteLine($"Hệ số lương: {HeSoLuong}");
            Console.WriteLine($"Phụ cấp: {PhuCap}");
            Console.WriteLine($"Tổng số lương: {TongLuong}");
        }
        public void TimNhanVien()
        {
            throw new NotImplementedException();
        }
    }
}
