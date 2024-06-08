using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE_2505.Buoi5.Bai25.Solution25;

namespace BE_2505.Buoi5.Bai25
{
    public class Solution25
    {
        public struct NhanVien
        {
            public string MaNhanVien;
            public string TenNhanVien;
            public DateTime NgayVaoCongTy;
            public float HeSoLuong;
            public string ViTriCongViec;
            public void NhapThongTin()
            {
                Console.WriteLine("\t\n---- Nhập thông tin nhân viên ----");
                Console.Write("Nhap mã số nhân viên: ");
                MaNhanVien = Console.ReadLine();
                Console.Write("Nhap Tên nhân viên: ");
                TenNhanVien = Console.ReadLine();
                Console.Write("Nhap ngay vao cong ty (dd/MM/yyyy): ");
                NgayVaoCongTy = DateTime.Parse(Console.ReadLine());
                Console.Write("Nhap Hệ số lương: ");
                HeSoLuong = float.Parse(Console.ReadLine());
            }
            public void XuatThongTin()
            {
                Console.WriteLine($"\na. Mã nhân viên: {MaNhanVien}");
                Console.WriteLine($"b. Tên: {TenNhanVien}");
                Console.WriteLine($"c. Ngày vào công ty: {NgayVaoCongTy}");
                Console.WriteLine($"d. Hệ số lương: {HeSoLuong}");
                Console.WriteLine($"e. Vị trí công việc: {HeSoLuong}");
            }
        }
        public void Menu(NhanVien[] nhanViens, int SoLuongNhanVien)
        {
            while (true)
            {
                Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ NHÂN VIÊN ----");
                Console.WriteLine("1. Nhập thông tin nhân viên.");
                Console.WriteLine("2. Nhập danh sách nhân viên từ file excel có sẵn.");
                Console.WriteLine("3. Hiển thị danh sách nhân viên.");
                Console.WriteLine("4. Xuất file excel danh sách các nhân viên theo các mốc.");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");
                int luachon = int.Parse(Console.ReadLine());
                if (luachon == 1)
                {
                    NhanVien nhanVien = new NhanVien();
                    nhanVien.NhapThongTin();
                    nhanViens[SoLuongNhanVien] = nhanVien;
                    SoLuongNhanVien++;
                }
                else if (luachon == 2)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\MIT\Desktop\NhanVien.xlsx")))
                    {
                        // Get the first worksheet in the file
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            NhanVien nhanVienNhapTuExcel = new NhanVien();
                            nhanVienNhapTuExcel.MaNhanVien = worksheet.Cells[row, 1].Value.ToString();
                            nhanVienNhapTuExcel.TenNhanVien = worksheet.Cells[row, 2].Value.ToString();
                            nhanVienNhapTuExcel.HeSoLuong = float.Parse(worksheet.Cells[row, 4].Value.ToString());
                            nhanVienNhapTuExcel.ViTriCongViec = worksheet.Cells[row, 4].Value.ToString();

                            nhanVienNhapTuExcel.NgayVaoCongTy = DateTime.Parse(worksheet.Cells[row, 3].Value.ToString(), CultureInfo.InvariantCulture);
                            //nhanVienNhapTuExcel.NgayVaoCongTy = DateTime.ParseExact(worksheet.Cells[row, 3].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            if (string.IsNullOrEmpty(nhanVienNhapTuExcel.MaNhanVien))
                            {
                                break;
                            }

                            nhanViens[SoLuongNhanVien] = nhanVienNhapTuExcel;
                            SoLuongNhanVien++;
                        }
                    }
                }
                else if (luachon == 3)
                {
                    Console.WriteLine("\t\n---- Xuất thông tin nhân viên ----");
                    for (int i = 0; i < SoLuongNhanVien; i++)
                    {
                        nhanViens[i].XuatThongTin();
                    }
                }
                else if (luachon == 4)
                {
                    Console.Write("Nhập số cột mốc năm mà nhân viên đó làm: ");
                    int CotMocNam = int.Parse(Console.ReadLine());
                    // Tạo file Excel và thêm dữ liệu
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage())
                    {
                        int ThuTuHangTrongFileExcel = 2;
                        var worksheet = package.Workbook.Worksheets.Add("NhanVien");

                        // Thêm tiêu đề cột
                        worksheet.Cells[1, 1].Value = "Id";
                        worksheet.Cells[1, 2].Value = "Họ tên";
                        worksheet.Cells[1, 3].Value = "Ngày vào công ty";
                        worksheet.Cells[1, 4].Value = "Hệ số lương";
                        worksheet.Cells[1, 5].Value = "Vị trí công việc";

                        // Thêm dữ liệu
                        for (int i = 0; i < SoLuongNhanVien; i++)
                        {
                            if (string.IsNullOrEmpty(nhanViens[i].MaNhanVien.ToString()))
                                break;
                            DateTime NgayHienTai = DateTime.Today;
                            int SoNamLamViec = NgayHienTai.Year - nhanViens[i].NgayVaoCongTy.Year;
                            if (SoNamLamViec >= CotMocNam) 
                            {
                                worksheet.Cells[ThuTuHangTrongFileExcel, 1].Value = nhanViens[i].MaNhanVien.ToString();
                                worksheet.Cells[ThuTuHangTrongFileExcel, 2].Value = nhanViens[i].TenNhanVien.ToString();
                                worksheet.Cells[ThuTuHangTrongFileExcel, 3].Value = nhanViens[i].NgayVaoCongTy.ToString();
                                worksheet.Cells[ThuTuHangTrongFileExcel, 4].Value = nhanViens[i].HeSoLuong.ToString();
                                worksheet.Cells[ThuTuHangTrongFileExcel, 5].Value = nhanViens[i].HeSoLuong.ToString();
                                ThuTuHangTrongFileExcel++;
                            }
                            
                        }

                        // Lưu file Excel
                        var filePath = @"C:\Users\MIT\Documents\temp\NhanVien.xlsx";
                        FileInfo fi = new FileInfo(filePath);
                        package.SaveAs(fi);

                        Console.WriteLine($"Excel file has been saved to {filePath}");
                    }
                }
            }
        }
        public void GiaiBai25()
        {
            int SoLuongNhanVien = 0;
            NhanVien[] nhanViens = new NhanVien[1000];
            Menu(nhanViens, SoLuongNhanVien);
        }
    }
}
