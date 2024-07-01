using BE_2505.Buoi10.Interface;
using BE_2505.Buoi7.Bai3;
using BE_2505.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            BE_2505.Common.ValidateData _ValidateData = new BE_2505.Common.ValidateData();
            Console.Write("Nhập tên Nhân viên: ");
            Name = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(Name))
            {
                Console.WriteLine("Định dạng Tên không đúng!");
                Environment.Exit(1);
            }

            Console.Write("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(GioiTinh))
            {
                Console.WriteLine("Định dạng GT không đúng!");
                Environment.Exit(1);
            }

            //Kiem tra đầu vào tuổi
            Console.Write("Nhập tuổi: ");
            string Tuoi_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<string>(Tuoi_Temp))
            {
                Console.WriteLine("Định dạng tuổi không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(Tuoi_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            Tuoi = int.Parse(Tuoi_Temp);

            //Kiểm tra đầu vào LCB
            Console.Write("Nhập lương cơ bản: ");
            string LuongCoBan_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<float>(LuongCoBan_Temp))
            {
                Console.WriteLine("Định dạng LCB không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(LuongCoBan_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            LuongCoBan = float.Parse(LuongCoBan_Temp);

            //Kiểm tra đầu vào HSL
            Console.Write("Nhập hệ số lương: ");
            string HeSoLuong_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<float>(HeSoLuong_Temp))
            {
                Console.WriteLine("Định dạng HSL không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(HeSoLuong_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            HeSoLuong = float.Parse(HeSoLuong_Temp);

            //Kiểm tra đầu vào PC
            Console.Write("Nhập Phụ cấp: ");
            string PhuCap_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<float>(PhuCap_Temp))
            {
                Console.WriteLine("Định dạng PC không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(PhuCap_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            PhuCap = float.Parse(PhuCap_Temp);

            //Kiểm tra đầu vào TL
            Console.Write("Nhập tổng số lương: ");
            string TongLuong_Temp = Console.ReadLine();
            if (!_ValidateData.PassCheckIputData<float>(TongLuong_Temp))
            {
                Console.WriteLine("Định dạng TL không đúng!");
                Environment.Exit(1);
            }
            else if (!_ValidateData.CheckPositiveNumber(int.Parse(TongLuong_Temp)))
            {
                Console.WriteLine("Input không được phép âm!");
                Environment.Exit(1);
            }
            TongLuong = float.Parse(TongLuong_Temp);
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
