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
            List<BaoCaoSanLuong> baoCaoSanLuongs = new List<BaoCaoSanLuong>();
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
                        BaoCaoSanLuong baoCaoSanLuong = new BaoCaoSanLuong();
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
                            baoCaoSanLuong.nhanVien = nhanVienSanLuong;
                            baoCaoSanLuong.sanLuongs.Add(sanLuong);
                            baoCaoSanLuongs.Add(baoCaoSanLuong);
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy nhân viên có mã ID {luaChonNhanVienSanLuong}");
                        }
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

                            worksheet.Cells[2, 3].Value = "Tổng";   

                            // Thêm dữ liệu
                            int index = 3;
                            float TongSanLuong = 0;
                            float TongThanhTien = 0;
                            foreach (var danhSachSanLuongTheoNhanVien in baoCaoSanLuongs)
                            {
                                foreach (var danhSachSanLuong in danhSachSanLuongTheoNhanVien.sanLuongs)
                                {
                                    worksheet.Cells[index, 1].Value = danhSachSanLuongTheoNhanVien.nhanVien.Name;
                                    worksheet.Cells[index, 2].Value = danhSachSanLuong.MaCongDoan;
                                    worksheet.Cells[index, 3].Value = danhSachSanLuong.TenCongDoan;
                                    worksheet.Cells[index, 4].Value = danhSachSanLuong.SoLuongSanPham;
                                    worksheet.Cells[index, 5].Value = danhSachSanLuong.GiaSanPham;
                                    worksheet.Cells[index, 6].Value = danhSachSanLuong.TinhGiaSanPham();
                                    index++;
                                }
                                TongSanLuong += danhSachSanLuongTheoNhanVien.TinhTongTheoNhanVien();
                                TongThanhTien += danhSachSanLuongTheoNhanVien.TinhTongThanhTien();
                                worksheet.Cells[index, 4].Value = danhSachSanLuongTheoNhanVien.TinhTongTheoNhanVien();
                                worksheet.Cells[index, 5].Value = 0;
                                worksheet.Cells[index, 6].Value = danhSachSanLuongTheoNhanVien.TinhTongThanhTien();
                                index++;
                            }
                            worksheet.Cells[2, 4].Value = TongSanLuong;
                            worksheet.Cells[2, 6].Value = TongThanhTien;
                            // Lưu file Excel
                            var filePath = @"D:\OneDrive - NEWTIMES DEVELOPMENT LTD\Desktop\NhanVienTheoSanLuong.xlsx";
                            FileInfo fi = new FileInfo(filePath);
                            package.SaveAs(fi);

                            Console.WriteLine($"Excel file has been saved to {filePath}");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
