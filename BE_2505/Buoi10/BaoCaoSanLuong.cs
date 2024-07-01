using BE_2505.Buoi10.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi10
{
    public class BaoCaoSanLuong : IBaoCaoSanLuong
    {
        public NhanVien nhanVien {  get; set; }
        public List<SanLuong> sanLuongs { get; set; }

        public float TinhTongTheoNhanVien()
        {
            return sanLuongs.Sum(x => x.SoLuongSanPham);
        }

        public float TinhTongThanhTien()
        {
            return this.TinhTongTheoNhanVien() * sanLuongs.Sum(x => x.GiaSanPham);
        }
    }
}
