using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi7.Bai1
{
    public class NhanVienThucTap : NhanVien
    {
        string PhuCapThang { get; set; }
        public override void TinhLuongNhanVien()
        {
            Console.WriteLine($"Lương nhân viên full time là: {PhuCapThang}");
        }
        public void NhapThongTinNhanVien()
        {
            base.NhapThongTinNhanVien();
            Console.Write("Nhập luong nhân viên partime: ");
            PhuCapThang = Console.ReadLine();
        }
        public void XuatThongTinNhanVien()
        {
            base.XuatThongTinNhanVien();
            Console.WriteLine($"Luong nhân viên fulltime: {PhuCapThang}");
        }
    }
}
