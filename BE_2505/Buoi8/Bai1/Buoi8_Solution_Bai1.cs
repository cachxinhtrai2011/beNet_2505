using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi8.Bai1
{
    public class Buoi8_Solution_Bai1
    {
        public void Menu()
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            while (true)
            {
                Console.Clear();
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
                    sinhVien.ID = Guid.NewGuid();
                    sinhVien.NhapThongTinSinhVien();
                    sinhViens.Add(sinhVien);
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
                            sinhVienNhapTuExcel.ID = Guid.NewGuid();
                            sinhVienNhapTuExcel.Ten = worksheet.Cells[row, 1].Value.ToString();
                            sinhVienNhapTuExcel.Tuoi = int.Parse(worksheet.Cells[row, 2].Value.ToString());
                            sinhVienNhapTuExcel.DiemLy = float.Parse(worksheet.Cells[row, 3].Value.ToString());
                            sinhVienNhapTuExcel.DiemHoa = float.Parse(worksheet.Cells[row, 4].Value.ToString());
                            sinhVienNhapTuExcel.DiemToan = float.Parse(worksheet.Cells[row, 5].Value.ToString());

                            if (string.IsNullOrEmpty(sinhVienNhapTuExcel.Ten))
                            {
                                break;
                            }

                            sinhViens.Add(sinhVienNhapTuExcel);
                        }
                    }
                }
                else if(luachon == 3)
                {
                    Console.WriteLine("---- Chọn tiêu chí ----");
                    Console.WriteLine("1. Tên");
                    Console.WriteLine("2. Học lực");
                    Console.WriteLine("3. Điểm trung bình");
                    Console.Write("Vui lòng chọn tiêu chí để sắp xếp: ");
                    int tieuChi = int.Parse(Console.ReadLine());
                    List<SinhVien> SinhVienSauKhiSapXep = new List<SinhVien>();
                    if (tieuChi == 1)
                    {
                        Console.WriteLine("---- Danh sách sinh viên sau khi sắp xếp theo tên ----");
                        SinhVienSauKhiSapXep = sinhViens.OrderBy(x => x.Ten).ToList();
                        foreach (var item in SinhVienSauKhiSapXep)
                        {
                            item.XuatThongTinSinhVien();
                        }
                    }
                    else if (tieuChi == 2)
                    {
                        Console.WriteLine("---- Danh sách sinh viên sau khi sắp xếp theo học lực ----");
                        SinhVienSauKhiSapXep = sinhViens.OrderBy(x => x.HocLuc).ToList();
                        foreach (var item in SinhVienSauKhiSapXep)
                        {
                            item.XuatThongTinSinhVien();
                        }
                    }
                    else if (tieuChi == 3)
                    {
                        Console.WriteLine("---- Danh sách sinh viên sau khi sắp xếp theo điểm trung bình ----");
                        SinhVienSauKhiSapXep = sinhViens.OrderBy(x => x.DiemTrungBinh).ToList();
                        foreach (var item in SinhVienSauKhiSapXep)
                        {
                            item.XuatThongTinSinhVien();
                        }
                    }
                }
                else if (luachon == 4)
                {
                    SinhVien sinhVienCapNhap = new SinhVien();
                    Console.WriteLine("---- Chọn sinh viên cần cập nhật ----");
                    for(int i = 0; i < sinhViens.Count(); i++)
                    {
                        Console.WriteLine($"\tSinh viên thứ {i + 1}");
                        sinhViens[i].XuatThongTinSinhVien();
                    }
                    Console.Write("Nhập thứ tự sinh viên cần cập nhật: ");
                    int luachonCapNhat = int.Parse(Console.ReadLine());
                    sinhVienCapNhap.NhapThongTinSinhVien();
                    sinhViens[luachonCapNhat - 1] = sinhVienCapNhap;
                    Console.WriteLine("--- \tThông tin sinh viên sau khi cập nhật ---");
                    sinhViens[luachonCapNhat - 1].XuatThongTinSinhVien();
                }
                else if(luachon == 5)
                {
                    Console.WriteLine("---- Chọn sinh viên cần xóa ----");
                    for (int i = 0; i < sinhViens.Count(); i++)
                    {
                        Console.WriteLine($"\tSinh viên thứ {i + 1}");
                        sinhViens[i].XuatThongTinSinhVien();
                    }
                    Console.Write("Nhập thứ tự sinh viên cần xóa (có thể nhập nhiều, cách nhau bởi khoảng trắng): ");
                    string luachonCapNhat = Console.ReadLine();
                    foreach (var item in luachonCapNhat.Split(" "))
                    {
                        Console.WriteLine($"Tiến hành xóa sinh viên thứ {item}");
                        sinhViens.RemoveAt(int.Parse(item) - 1);
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
            Menu();
        }
    }
}
