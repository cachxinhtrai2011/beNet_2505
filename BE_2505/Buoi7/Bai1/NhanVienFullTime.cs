using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE_2505.Buoi5.Bai25.Solution25;

namespace BE_2505.Buoi7.Bai1
{
    public class NhanVienFullTime : NhanVien
    {
        string LuongTheoThang { get; set; }
        public override void TinhLuongNhanVien()
        {
            Console.WriteLine($"Lương nhân viên full time là: {LuongTheoThang}");
        }
        public void NhapThongTinNhanVien()
        {
            base.NhapThongTinNhanVien();
            Console.Write("Nhập luong nhân viên fulltime: ");
            LuongTheoThang = Console.ReadLine();
        }
        public void XuatThongTinNhanVien()
        {
            base.XuatThongTinNhanVien();
            Console.WriteLine($"Luong nhân viên fulltime: {LuongTheoThang}");
        }
    }
}
