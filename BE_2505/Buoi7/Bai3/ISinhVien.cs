using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi7.Bai3
{
    public interface ISinhVien
    {
        string ID { get; set; }
        string Ten { get; set; }
        string GioiTinh { get; set; }
        int Tuoi { get; set; }
        double DiemToan { get; set; }
        double DiemLy { get; set; }
        double DiemHoa { get; set; }
        double DiemTrungBinh { get; set; }
        string HocLuc { get; set; }
        void TinhDiemTrungBinh();
        void NhapThongTinSinhVien();
        void XuatThongTinSinhVien();
    }
}
