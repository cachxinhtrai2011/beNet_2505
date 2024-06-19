using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi7.Bai2
{
    public class LapTop : SanPham
    {
        public override void TinhGiaBanSanPham()
        {
            Console.WriteLine($"Giá bán của sản phẩm: {GiaBan}");
        }
    }
}
