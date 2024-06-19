using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi7.Bai3
{
    public class SinhVien : ISinhVien
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public double DiemToan { get; set; }
        public double DiemLy { get; set; }
        public double DiemHoa { get; set; }
        public double DiemTrungBinh { get; set; }
        public string HocLuc { get; set; }

        public void TinhDiemTrungBinh()
        {
            DiemTrungBinh = (DiemToan + DiemLy + DiemHoa) / 3;
            if(DiemTrungBinh >= 8)
            {
                HocLuc = "Giỏi";
            }
            else if(DiemTrungBinh >= 6.5)
            {
                HocLuc = "Khá";
            }
            else if(DiemTrungBinh >= 5)
            {
                HocLuc = "TrungBinh";
            }
            else
            {
                HocLuc = "Yếu";
            }
        }
        public void NhapThongTinSinhVien()
        {
            Console.Write("Nhập tên: ");
            Ten = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            GioiTinh = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhập điểm toán: ");
            DiemToan = float.Parse(Console.ReadLine());
            Console.Write("Nhập điểm lý: ");
            DiemLy = float.Parse(Console.ReadLine());
            Console.Write("Nhập điểm hóa: ");
            DiemHoa = float.Parse(Console.ReadLine());
        }
        public void XuatThongTinSinhVien()
        {
            Console.WriteLine($"Tên: {Ten}");
            Console.WriteLine($"Giới tính: {GioiTinh}");
            Console.WriteLine($"Tuổi: {Tuoi}");
            Console.WriteLine($"Điểm toán: {DiemToan}");
            Console.WriteLine($"Điểm lý: {DiemLy}");
            Console.WriteLine($"Điểm hóa: {DiemHoa}");
            Console.WriteLine($"Điểm trung bình: {DiemTrungBinh}");
            Console.WriteLine($"Học lực: {HocLuc}");
        }
    }
}
