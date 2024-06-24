using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi8.Bai1
{
    public class SinhVien : ISinhVien
    {
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public float DiemToan { get; set; }
        public float DiemLy { get; set; }
        public float DiemHoa { get; set; }
        public float DiemTrungBinh { get; set; }
        public string HocLuc {  get; set; }
        public void NhapThongTinSinhVien()
        {
            ValidateDataInsert validateDataInsert = new ValidateDataInsert();
            Console.Write("Nhập tên: ");
            string Ten_Temp = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            string GioiTinh_Temp = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            string Tuoi_Temp = Console.ReadLine();
            Console.Write("Nhập điểm toán: ");
            string DiemToan_Temp = Console.ReadLine();
            Console.Write("Nhập điểm lý: ");
            string DiemLy_Temp = Console.ReadLine();
            Console.Write("Nhập điểm hóa: ");
            string DiemHoa_Temp = Console.ReadLine();
            var ReturnData = validateDataInsert.KiemTraKhiNhapSinhVien(Ten_Temp, GioiTinh_Temp, Tuoi_Temp, DiemLy_Temp, DiemHoa_Temp, DiemToan_Temp);
            if(ReturnData.ResponseCode == 1)
            {
                ID = Guid.NewGuid();
                Ten = Ten_Temp;
                GioiTinh = GioiTinh_Temp;
                Tuoi = int.Parse(Tuoi_Temp);
                DiemToan = float.Parse(DiemToan_Temp);
                DiemLy = float.Parse(DiemLy_Temp);
                DiemHoa = float.Parse(DiemHoa_Temp);
            }
        }
        public void XuatThongTinSinhVien()
        {
            TinhDiemTrungBinh();
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Tên: {Ten}");
            Console.WriteLine($"Giới tính: {GioiTinh}");
            Console.WriteLine($"Tuổi: {Tuoi}");
            Console.WriteLine($"Điểm toán: {DiemToan}");
            Console.WriteLine($"Điểm lý: {DiemLy}");
            Console.WriteLine($"Điểm hóa: {DiemHoa}");
            Console.WriteLine($"Điểm trung bình: {DiemTrungBinh}");
            Console.WriteLine($"Học lực: {HocLuc}");
        }
        public void TinhDiemTrungBinh()
        {
            DiemTrungBinh = (DiemToan + DiemLy + DiemHoa) / 3;
            if (DiemTrungBinh >= 8)
            {
                HocLuc = "Giỏi";
            }
            else if (DiemTrungBinh >= 6.5)
            {
                HocLuc = "Khá";
            }
            else if (DiemTrungBinh >= 5)
            {
                HocLuc = "TrungBinh";
            }
            else
            {
                HocLuc = "Yếu";
            }
        }
    }
}
