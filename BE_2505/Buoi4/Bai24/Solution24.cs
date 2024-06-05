using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BE_2505.Buoi4.Bai24
{
    public class Solution24
    {
        /*
        Bài 24: Viết chương trình thực hiện phân tích thống kê cho một lớp học khoảng 5 sinh viên sử dụng menu lựa chọn.
        Thông tin của mỗi sinh viên bao gồm ID, tên, tuổi, điểm tổng kết học kì 1, điểm tổng kết học kì 2. 
        Thông tin xếp loại học lực được định nghĩa bằng enum : Xuất sắc , giỏi , khá ,trung bình, yếu

        Thực hiện các chức năng sau:
        1.Thực hiện nhập danh sách các sinh viên trên
        2.Hiển thị danh sách sinh viên và điểm tổng kết cuối năm của sinh viên nào là cao nhất.
        3.Liệt kê danh sách những sinh viên có tiến bộ trong học tập(điểm tổng kết học kì 2 cao hơn điểm tổng kết học kì 1).
        4.Tìm kiếm theo ID, Tên sinh viên, loại học lực
        5.Xuất danh sách sinh viên ra file Excel theo các tiêu chí tìm kiếm ở trên
        */
        enum Enum_HocLuc
        {
            XUAT_SAC = 1,
            GIOI = 2,
            KHA = 3,
            TRUNG_BINH = 4,
            YEU = 5
        }
        public struct SinhVien
        {
            public string ID;
            public string Ten;
            public int Tuoi;
            public float DiemTongKetHK1;
            public float DiemTongKetHK2;
            public int HocLuc;

            public void NhapThongTin()
            {
                Console.Write("Nhap MSSV: ");
                ID = Console.ReadLine();
                Console.Write("Nhap ten: ");
                Ten = Console.ReadLine();
                Console.Write("Nhap tuoi: ");
                Tuoi = int.Parse(Console.ReadLine());
                Console.Write("Nhap Diem Tong Ket HK1: ");
                DiemTongKetHK1 = float.Parse(Console.ReadLine());
                Console.Write("Nhap Diem Tong Ket HK2: ");
                DiemTongKetHK2 = float.Parse(Console.ReadLine());
                Console.Write("Nhap hoc luc: ");
                HocLuc = int.Parse(Console.ReadLine());
            }
            public void NhapThongTinKetHopBoLoc()
            {
                Console.WriteLine("\n\t Nhập thông tin với bộ lọc");
                Console.Write("Nhap MSSV: ");
                ID = Console.ReadLine();
                Console.Write("Nhap ten: ");
                Ten = Console.ReadLine();
                Console.Write("Nhap hoc luc: ");
                HocLuc = int.Parse(Console.ReadLine());
            }
            public void XuatThongTin()
            {
                Console.WriteLine($"\na. MSSV: {ID}");
                Console.WriteLine($"b. Ten: {Ten}");
                Console.WriteLine($"c. Tuoi: {Tuoi}");
                Console.WriteLine($"d. Diem Tong Ket HK1: {DiemTongKetHK1}");
                Console.WriteLine($"e. Diem Tong Ket HK2: {DiemTongKetHK2}");
                if (HocLuc == Convert.ToInt32(Enum_HocLuc.XUAT_SAC))
                {
                    Console.WriteLine($"Hoc Luc: Xuat Sac");
                }
                else if (HocLuc == Convert.ToInt32(Enum_HocLuc.GIOI))
                {
                    Console.WriteLine($"Hoc Luc: Gioi");
                }
                else if (HocLuc == Convert.ToInt32(Enum_HocLuc.KHA))
                {
                    Console.WriteLine($"Hoc Luc: Kha");
                }
                else if (HocLuc == Convert.ToInt32(Enum_HocLuc.TRUNG_BINH))
                {
                    Console.WriteLine($"Hoc Luc: Trung Binh");
                }
                else
                {
                    Console.WriteLine($"Hoc Luc: Yeu");
                }
            }
            public void XuatExcelSinhVien(SinhVien sinhVienXuatExcel)
            {

            }
        }

        public void Menu(SinhVien[] sinhViens, int SoLuongSinhVien)
        {
            while (true)
            {
                Console.WriteLine("\n\n\t\t ---- CHUONG TRINH QUAN LY SINH VIEN ----");
                Console.WriteLine("1. Nhap thong tin sinh vien.");
                Console.WriteLine("2. Hiển thị danh sách sinh viên và điểm tổng kết cuối năm của sinh viên nào là cao nhất.");
                Console.WriteLine("3. Liệt kê danh sách những sinh viên có tiến bộ trong học tập(điểm tổng kết học kì 2 cao hơn điểm tổng kết học kì 1).");
                Console.WriteLine("4. Tìm kiếm theo ID, Tên sinh viên, loại học lực.");
                Console.WriteLine("5. Xuất danh sách sinh viên ra file Excel theo các tiêu chí tìm kiếm ở trên");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");
                int luachon = int.Parse(Console.ReadLine());
                if (luachon == 0)
                {
                    break;
                }
                else if (luachon == 1)
                {
                    SinhVien nhapThongTinSinhVien = new SinhVien();
                    nhapThongTinSinhVien.NhapThongTin();
                    sinhViens[SoLuongSinhVien] = nhapThongTinSinhVien;
                    SoLuongSinhVien++;
                }
                else if (luachon == 2)
                {
                    float diemTongKetCuoiNam = 0;
                    SinhVien xuatThongTinSinhVienCoDiemTongKetCaoNhat = new SinhVien();
                    for (int i = 0; i < SoLuongSinhVien; i++)
                    {
                        sinhViens[i].XuatThongTin();
                        if (diemTongKetCuoiNam < sinhViens[i].DiemTongKetHK1 + sinhViens[i].DiemTongKetHK2)
                        {
                            diemTongKetCuoiNam = sinhViens[i].DiemTongKetHK1 + sinhViens[i].DiemTongKetHK2;
                            xuatThongTinSinhVienCoDiemTongKetCaoNhat = sinhViens[i];
                        }
                    }
                    Console.WriteLine("\n\t Thông tin sinh viên có điểm trung bình cao nhất");
                    xuatThongTinSinhVienCoDiemTongKetCaoNhat.XuatThongTin();
                }
                else if (luachon == 3)
                {
                    Console.WriteLine("Danh sách những sinh viên có tiến bộ trong học tập (điểm tổng kết học kì 2 cao hơn điểm tổng kết học kì 1)");
                    for (int i = 0; i < SoLuongSinhVien; i++)
                    {
                        if (sinhViens[i].DiemTongKetHK1 < sinhViens[i].DiemTongKetHK2)
                        {
                            sinhViens[i].XuatThongTin();
                        }
                    }
                }
                else if (luachon == 4)
                {
                    SinhVien nhapThongTinSinhVienVoiBoLoc = new SinhVien();
                    SinhVien[] danhSachSinhVienXuatExcel = new SinhVien[SoLuongSinhVien];

                    int soLuongSinhVienXuatExcel = 0;
                    nhapThongTinSinhVienVoiBoLoc.NhapThongTinKetHopBoLoc();
                    for (int i = 0; i < SoLuongSinhVien; i++)
                    {
                        if (sinhViens[i].ID == nhapThongTinSinhVienVoiBoLoc.ID
                            || sinhViens[i].Ten == nhapThongTinSinhVienVoiBoLoc.Ten
                            || sinhViens[i].HocLuc == nhapThongTinSinhVienVoiBoLoc.HocLuc)
                        {
                            sinhViens[i].XuatThongTin();
                            danhSachSinhVienXuatExcel[soLuongSinhVienXuatExcel] = sinhViens[i];
                            soLuongSinhVienXuatExcel++;
                        }
                    }
                    Console.Write("\n\tXuất Excel? (1/0): ");
                    luachon = int.Parse(Console.ReadLine());
                    if (luachon == 1)
                    {
                        // Tạo file Excel và thêm dữ liệu
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("SinhVien");

                            // Thêm tiêu đề cột
                            worksheet.Cells[1, 1].Value = "Id";
                            worksheet.Cells[1, 2].Value = "Họ tên";
                            worksheet.Cells[1, 3].Value = "Tuổi";
                            worksheet.Cells[1, 4].Value = "Điểm tổng kết HK1";
                            worksheet.Cells[1, 5].Value = "Điểm tổng kết HK2";
                            worksheet.Cells[1, 6].Value = "Hoc Luc";

                            // Thêm dữ liệu
                            for (int i = 0; i < SoLuongSinhVien; i++)
                            {
                                if (string.IsNullOrEmpty(danhSachSinhVienXuatExcel[i].ID))
                                    break;
                                worksheet.Cells[i + 2, 1].Value = danhSachSinhVienXuatExcel[i].ID;
                                worksheet.Cells[i + 2, 2].Value = danhSachSinhVienXuatExcel[i].Ten;
                                worksheet.Cells[i + 2, 3].Value = danhSachSinhVienXuatExcel[i].Tuoi;
                                worksheet.Cells[i + 2, 4].Value = danhSachSinhVienXuatExcel[i].DiemTongKetHK1;
                                worksheet.Cells[i + 2, 5].Value = danhSachSinhVienXuatExcel[i].DiemTongKetHK2;
                                if (danhSachSinhVienXuatExcel[i].HocLuc == Convert.ToInt32(Enum_HocLuc.XUAT_SAC))
                                {
                                    worksheet.Cells[i + 2, 6].Value = "Xuất sắc";
                                }
                                else if (danhSachSinhVienXuatExcel[i].HocLuc == Convert.ToInt32(Enum_HocLuc.GIOI))
                                {
                                    worksheet.Cells[i + 2, 6].Value = "Giỏi";
                                }
                                else if (danhSachSinhVienXuatExcel[i].HocLuc == Convert.ToInt32(Enum_HocLuc.KHA))
                                {
                                    worksheet.Cells[i + 2, 6].Value = "Khá";
                                }
                                else if (danhSachSinhVienXuatExcel[i].HocLuc == Convert.ToInt32(Enum_HocLuc.TRUNG_BINH))
                                {
                                    worksheet.Cells[i + 2, 6].Value = "Trung bình";
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, 6].Value = "Yếu";
                                }
                            }

                            // Lưu file Excel
                            var filePath = @"C:\Users\MIT\Documents\temp\SinhVien.xlsx";
                            FileInfo fi = new FileInfo(filePath);
                            package.SaveAs(fi);

                            Console.WriteLine($"Excel file has been saved to {filePath}");
                        }
                    }
                }
            }
        }
        public void GiaiBai24()
        {
            SinhVien[] sinhViens = new SinhVien[100];
            int soLuongSinhVien = 0;
            Menu(sinhViens, soLuongSinhVien);
        }
    }
}
