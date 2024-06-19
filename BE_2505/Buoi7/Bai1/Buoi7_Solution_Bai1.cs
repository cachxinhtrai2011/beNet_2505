using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi7.Bai1
{
    public class Buoi7_Solution_Bai1
    {
        public void Menu(NhanVienFullTime[] nhanVienFullTimes, NhanVienPartTime[] nhanVienPartTimes, NhanVienThucTap[] nhanVienThucTaps, int SoLuongNhanVienFullTime, int SoLuongNhanVienPartTime, int SoLuongNhanVienIntern)
        {
            while (true)
            {
                BE_2505.Common.ValidateData _ValidateData = new BE_2505.Common.ValidateData();
                Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ NHÂN VIÊN ----");
                Console.WriteLine("1. Nhập thông tin FullTime.");
                Console.WriteLine("2. Xuất thông tin FullTime.");
                Console.WriteLine("3. Nhập thông tin PartTime.");
                Console.WriteLine("4. Xuất thông tin PartTime.");
                Console.WriteLine("5. Nhập thông tin Intern.");
                Console.WriteLine("6. Xuất thông tin Intern.");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");

                int luachon = int.Parse(Console.ReadLine());
                if (luachon == 1)
                {
                    NhanVienFullTime nhanVienFullTime = new NhanVienFullTime();
                    nhanVienFullTime.NhapThongTinNhanVien();
                    nhanVienFullTimes[SoLuongNhanVienFullTime] = nhanVienFullTime;
                    SoLuongNhanVienFullTime++;
                }
                else if (luachon == 2)
                {
                    Console.WriteLine("\r\n---- Xuất thông tin Nhân viên FullTime ----");
                    for (int i = 0; i < SoLuongNhanVienFullTime; i++)
                    {
                        nhanVienFullTimes[i].XuatThongTinNhanVien();
                    }
                }
                else if (luachon == 3)
                {
                    NhanVienPartTime nhanVienPartTime = new NhanVienPartTime();
                    nhanVienPartTime.NhapThongTinNhanVien();
                    nhanVienPartTimes[SoLuongNhanVienPartTime] = nhanVienPartTime;
                    SoLuongNhanVienPartTime++;
                }
                else if (luachon == 4)
                {
                    Console.WriteLine("\r\n---- Xuất thông tin Nhân viên PartTime ----");
                    for (int i = 0; i < SoLuongNhanVienPartTime; i++)
                    {
                        nhanVienPartTimes[i].XuatThongTinNhanVien();
                    }
                }
                else if (luachon == 5)
                {
                    NhanVienThucTap nhanVienThucTap = new NhanVienThucTap();
                    nhanVienThucTap.NhapThongTinNhanVien();
                    nhanVienThucTaps[SoLuongNhanVienIntern] = nhanVienThucTap;
                    SoLuongNhanVienIntern++;
                }
                else if (luachon == 6)
                {
                    Console.WriteLine("\r\n---- Xuất thông tin Nhân viên PartTime ----");
                    for (int i = 0; i < SoLuongNhanVienIntern; i++)
                    {
                        nhanVienThucTaps[i].XuatThongTinNhanVien();
                    }
                }
                else
                {
                    break;
                }
            }
        }
        public void GiaiBai1()
        {
            NhanVienFullTime[] nhanVienFullTimes = new NhanVienFullTime[100];
            NhanVienPartTime[] nhanVienPartTimes = new NhanVienPartTime[100];
            NhanVienThucTap[] nhanVienThucTaps = new NhanVienThucTap[100];
            Menu(nhanVienFullTimes, nhanVienPartTimes, nhanVienThucTaps, 0, 0, 0);
        }
    }
}
