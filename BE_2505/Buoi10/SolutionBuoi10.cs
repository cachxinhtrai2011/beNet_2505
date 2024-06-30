using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi10
{
    public class SolutionBuoi10
    {
        public void Menu()
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            List<SanLuong> sanLuongs = new List<SanLuong>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ NHÂN VIÊN ----");
                Console.WriteLine("1. Nhập thông tin nhân viên.");
                Console.WriteLine("2. Tạo sản lượng theo công đoạn của từng nhân viên.");
                Console.WriteLine("3. Xuất và hiển thị báo cáo (như ảnh đính kèm).");
                Console.WriteLine("4. Xuất thông tin nhân viên.");
                Console.WriteLine("5. Xuất thông tin sản lượng và công đoạn của từng nhân viên.");
                Console.WriteLine("6. Tìm kiếm nhân viên theo tên.");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");
                int luachon = int.Parse(Console.ReadLine());
                switch(luachon)
                {
                    case 1:
                        NhanVien nhanVien = new NhanVien();
                        nhanVien.Id = Guid.NewGuid();
                        nhanVien.ThemNhanVien();
                        nhanViens.Add(nhanVien);
                        break;
                    case 2:
                        SanLuong sanLuong = new SanLuong();
                        Console.WriteLine("----\t\tChọn nhân viên cần thêm sản lượng theo công đoạn.");
                        for(int i = 0; i< nhanViens.Count; i++)
                        {
                            nhanViens[i].XuatThongTinNhanVien();
                        }
                        Console.Write("Nhập ID nhân viên cần thêm: ");
                        Guid luaChonNhanVienSanLuong = Guid.Parse(Console.ReadLine());
                        Console.WriteLine("\tNhập thông tin sản lượng theo công đoạn:");
                        sanLuong.NhapSanLuong();
                        var nhanVienSanLuong = nhanViens.Where(x => x.Id == luaChonNhanVienSanLuong).FirstOrDefault();
                        if(nhanVienSanLuong != null)
                        {
                            sanLuong.nhanVien = nhanVienSanLuong;
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy nhân viên có mã ID {luaChonNhanVienSanLuong}");
                        }
                        sanLuongs.Add(sanLuong);
                        break;
                    case 3:
                        // Tạo file Excel và thêm dữ liệu
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("NhanVien");

                            // Thêm tiêu đề cột
                            worksheet.Cells[1, 1].Value = "Name";
                            worksheet.Cells[1, 2].Value = "Process";
                            worksheet.Cells[1, 3].Value = "Process_Name";
                            worksheet.Cells[1, 4].Value = "Qty";
                            worksheet.Cells[1, 5].Value = "Price";
                            worksheet.Cells[1, 6].Value = "Total";

                            // Thêm dữ liệu
                            for (int i = 0; i < sanLuongs.Count; i++)
                            {
                                if (string.IsNullOrEmpty(sanLuongs[i].nhanVien.Id.ToString()))
                                    break;
                                worksheet.Cells[i + 2, 1].Value = sanLuongs[i].nhanVien.Name;
                                worksheet.Cells[i + 2, 2].Value = sanLuongs[i].MaCongDoan;
                                worksheet.Cells[i + 2, 3].Value = sanLuongs[i].TenCongDoan;
                                worksheet.Cells[i + 2, 4].Value = sanLuongs[i].SoLuongSanPham;
                                worksheet.Cells[i + 2, 5].Value = sanLuongs[i].GiaSanPham;
                                worksheet.Cells[i + 2, 6].Value = sanLuongs[i].TinhGiaSanPham();
                            }

                            // Lưu file Excel
                            var filePath = @"C:\Users\MIT\Documents\temp\SinhVien.xlsx";
                            FileInfo fi = new FileInfo(filePath);
                            package.SaveAs(fi);

                            Console.WriteLine($"Excel file has been saved to {filePath}");
                        }
                        break;
                }
            }
        }
    }
}
