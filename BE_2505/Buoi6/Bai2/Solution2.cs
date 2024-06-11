using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.Common;

namespace BE_2505.Buoi6.Bai2
{
    public class Solution2
    {
        /*
         Bài 2.Tạo một lớp Student với các thuộc tính: ID, Name, Grade. Sau đó:Tạo một Dictionary<int, Student> để quản lý sinh viên theo ID.Thêm một vài sinh viên vào dictionary.Sử dụng LINQ để thực hiện các truy vấn:
        Tìm sinh viên có điểm số cao nhất.
        Lấy danh sách tên sinh viên có điểm lớn hơn một giá trị cho trước.
        Đếm số lượng sinh viên đạt điểm trung bình trở lên.
         */
        public struct Student
        {
            public string Id;
            public string Name;
            public float Grade;
            //public Student(int _Id, string _Name, float _Grade)
            //{
            //    this.Id = _Id;
            //    this.Name = _Name;
            //    this.Grade = _Grade;
            //}
            public void NhapThongTin()
            {
                BE_2505.Common.ValidateData _ValidateData = new BE_2505.Common.ValidateData();
                Console.WriteLine("\r\n---- Nhập thông tin học sinh ----");
                Console.Write("Nhập thông tin mã học sinh: ");
                Id = Console.ReadLine();
                if (!_ValidateData.PassCheckIputData<string>(Id))
                {
                    Console.WriteLine("Định dạng mã học sinh không đúng!");
                    Environment.Exit(1);
                }

                Console.Write("Nhập tên học sinh: ");
                Name = Console.ReadLine();
                if (!_ValidateData.PassCheckIputData<string>(Name))
                {
                    Console.WriteLine("Định dạng tên không đúng!");
                    Environment.Exit(1);
                }

                Console.Write("Nhập điểm học sinh: ");
                string Grade_Temp = Console.ReadLine();
                if (!_ValidateData.PassCheckIputData<float>(Grade_Temp))
                {
                    Console.WriteLine("Định dạng điểm không đúng!");
                    Environment.Exit(1);
                }
                else if (!_ValidateData.CheckPositiveNumber(int.Parse(Grade_Temp)))
                {
                    Console.WriteLine("Input không được phép âm!");
                    Environment.Exit(1);
                }
                Grade = float.Parse(Grade_Temp);
            }
            public void XuatThongTin()
            {
                Console.WriteLine($"- Mã học sinh: {Id}");
                Console.WriteLine($"- Tên học sinh: {Name}");
                Console.WriteLine($"- Điểm học sinh: {Grade}");
            }
        }
        public void Menu(Dictionary<string, Student> Students_Dictionary)
        {
            while (true)
            {
                BE_2505.Common.ValidateData _ValidateData = new BE_2505.Common.ValidateData();
                Console.Clear();
                Console.WriteLine("\n\n\t\t ---- CHƯƠNG TRÌNH QUẢN LÝ HỌC SINH ----");
                Console.WriteLine("1. Nhập thông tin học sinh.");
                Console.WriteLine("2. Xuất thông tin học sinh.");
                Console.WriteLine("3. Tìm học sinh có điểm số cao nhất.");
                Console.WriteLine("4. Lấy danh sách tên sinh viên có điểm lớn hơn một giá trị cho trước.");
                Console.WriteLine("5. Đếm số lượng sinh viên đạt điểm trung bình trở lên.");
                Console.WriteLine("0. Nhập 0 để thoát khỏi chương trình!");
                Console.WriteLine("\t\t ---- END ----");

                Console.Write("Nhập lựa chọn: ");

                int luachon = int.Parse(Console.ReadLine());
                if (luachon == 1)
                {
                    Student student = new Student();
                    student.NhapThongTin();
                    if (!Students_Dictionary.ContainsKey(student.Id))
                    {
                        Students_Dictionary.Add(student.Id, student);
                    }
                    else
                    {
                        Console.WriteLine($"\n\tMã học sinh {student.Id} đã tồn tại. Vui lòng kiểm tra lại!");
                    }
                }
                else if (luachon == 2)
                {
                    Console.WriteLine("\r\n---- Xuất thông tin học sinh ----");
                    foreach (KeyValuePair<string, Student> student in Students_Dictionary)
                    {
                        student.Value.XuatThongTin();
                    }
                }
                else if (luachon == 3)
                {
                    Console.WriteLine("\r\n---- Xuất thông tin học sinh có điểm cao nhất họ ----");
                    var HocSinh_DiemCaoNhat = Students_Dictionary.OrderByDescending(kvp => kvp.Value.Grade).FirstOrDefault();
                    HocSinh_DiemCaoNhat.Value.XuatThongTin();
                }
                else if (luachon == 4)
                {
                    Console.Write("Nhập điểm cần so sánh: ");
                    float diemCanSoSanh = float.Parse(Console.ReadLine());

                    Console.WriteLine($"\r\n---- Xuất thông tin học sinh có điểm cao hơn {diemCanSoSanh} ----");
                    var HocSinh_DiemCaoHon_DiemCanSoSanh = Students_Dictionary.Where(kvp => kvp.Value.Grade > diemCanSoSanh);
                    foreach (KeyValuePair<string, Student> student in HocSinh_DiemCaoHon_DiemCanSoSanh)
                    {
                        student.Value.XuatThongTin();
                        Console.WriteLine();
                    }
                }
                else if (luachon == 5)
                {
                    var HocSinh_SoLuongDiemTrenTrungBinh = Students_Dictionary.Where(kvp => kvp.Value.Grade > 5).Count();
                    Console.WriteLine($"\r\n---- Số lượng học sinh có điểm cao hơn có điểm trên trung bình: {HocSinh_SoLuongDiemTrenTrungBinh} ----");
                }
                else
                {
                    break;
                }
            }
        }
        public void GiaiBai2()
        {
            Dictionary<string, Student> Students_Dictionary = new Dictionary<string, Student>();
            Menu(Students_Dictionary);
        }
    }
}
