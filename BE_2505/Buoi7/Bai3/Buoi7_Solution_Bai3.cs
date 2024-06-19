using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BE_2505.Buoi4.Bai24.Solution24;

namespace BE_2505.Buoi7.Bai3
{
    public class Buoi7_Solution_Bai3
    {
        public void Menu(SinhVien[] sinhViens, int SoLuongSinhVien)
        {
            while (true)
            {
                Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN ----");
                Console.WriteLine("1. Nhập thông tin sinh viên.");
                Console.WriteLine("2. Nhập danh sách sinh viên từ file excel có sẵn.");
                Console.WriteLine("3. Sắp xếp sinh viên theo các tiêu chí ( tên , học lực , điêm trung bình ).");
                Console.WriteLine("4. Cập nhật thông tin sinh viên bởi ID.");
                Console.WriteLine("5. Xóa sinh viên bởi ID và cho phép xóa nhiều sinh viên cùng lúc.");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");
                int luachon = int.Parse(Console.ReadLine());
                if (luachon == 1)
                {
                    SinhVien sinhVien = new SinhVien();
                    sinhVien.ID = SoLuongSinhVien.ToString();
                    sinhVien.NhapThongTinSinhVien();
                    sinhViens[SoLuongSinhVien] = sinhVien;
                    SoLuongSinhVien++;
                }
                else if (luachon == 2)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(@"C:\Users\MIT\Desktop\SinhVien.xlsx")))
                    {
                        // Get the first worksheet in the file
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            SinhVien sinhVienNhapTuExcel = new SinhVien();
                            sinhVienNhapTuExcel.ID = SoLuongSinhVien.ToString();
                            sinhVienNhapTuExcel.Ten = worksheet.Cells[row, 1].Value.ToString();
                            sinhVienNhapTuExcel.Tuoi = int.Parse(worksheet.Cells[row, 2].Value.ToString());
                            sinhVienNhapTuExcel.DiemLy = float.Parse(worksheet.Cells[row, 3].Value.ToString());
                            sinhVienNhapTuExcel.DiemHoa = float.Parse(worksheet.Cells[row, 4].Value.ToString());
                            sinhVienNhapTuExcel.DiemToan = float.Parse(worksheet.Cells[row, 5].Value.ToString());

                            if (string.IsNullOrEmpty(sinhVienNhapTuExcel.Ten))
                            {
                                break;
                            }

                            sinhViens[SoLuongSinhVien] = sinhVienNhapTuExcel;
                            SoLuongSinhVien++;
                        }
                    }
                }
                else if (luachon == 4)
                {
                    Console.Write("Nhập ID cần cập nhật: ");
                    string ID_SinhVien_CapNhap = Console.ReadLine();
                    var SinhVienCanCapNhat = sinhViens.Where(y => y.ID.Equals(ID_SinhVien_CapNhap)).FirstOrDefault();
                    SinhVienCanCapNhat.XuatThongTinSinhVien();
                    Console.WriteLine("\r\r\nNhập thông tin chỉnh sửa");
                    sinhViens[int.Parse(SinhVienCanCapNhat.ID)].NhapThongTinSinhVien();
                }
            }
        }
    }
}
