using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi4.Bai23
{
    public class Solution23
    {
        //Bài 23: Hãy định nghĩa kiểu dữ liệu PhanSo đại diện cho kiểu phân số. Qua đó, viết chương trình cho phép người dùng thực hiện các phép cộng, trừ, nhân, chia 2 phân số.
        struct PhanSo
        {
            public float tuSo;
            public float mauSo;

            public PhanSo(float _tuSo, float _mauSo)
            {
                if (_mauSo == 0)
                {
                    Console.WriteLine("Mau so khong duoc phep bang 0!");
                    return;
                }
                else if (_mauSo < 0) {
                    //nếu mẫu số = 0 thì sẽ nhân tử số với -1
                    _tuSo = _tuSo * (-1);
                }
                this.tuSo = _tuSo;
                this.mauSo = _mauSo;
            }
            public void CongPhanSo(PhanSo phanSoCong) 
            {
                PhanSo phanSoRutGon = new PhanSo();
                if (phanSoCong.mauSo == mauSo)
                {
                    phanSoRutGon.tuSo = tuSo + phanSoCong.tuSo;
                    phanSoRutGon.mauSo = mauSo;
                }
                else
                {
                    phanSoRutGon.tuSo = phanSoCong.tuSo * mauSo + phanSoCong.mauSo * tuSo;
                    phanSoRutGon.mauSo = phanSoCong.mauSo * mauSo;
                }
                phanSoRutGon.RutGonPhanSo();
                Console.WriteLine($"Ket qua phep cong: {phanSoRutGon.tuSo}/{phanSoRutGon.mauSo}");
            }
            public void TruPhanSo(PhanSo phanSoTru)
            {
                PhanSo phanSoRutGon = new PhanSo();
                if (phanSoTru.mauSo == mauSo)
                {
                    phanSoRutGon.tuSo = tuSo - phanSoTru.tuSo;
                    phanSoRutGon.mauSo = mauSo;
                }
                else
                {
                    phanSoRutGon.tuSo = phanSoTru.mauSo * tuSo - phanSoTru.tuSo * mauSo;
                    phanSoRutGon.mauSo = phanSoTru.mauSo * mauSo;
                }
                phanSoRutGon.RutGonPhanSo();
                Console.WriteLine($"Ket qua phep tru: {phanSoRutGon.tuSo}/{phanSoRutGon.mauSo}");
            }
            public void NhanPhanSo(PhanSo phanSoNhan)
            {
                PhanSo phanSoRutGon = new PhanSo();
                phanSoRutGon.tuSo = tuSo * phanSoNhan.tuSo;
                phanSoRutGon.mauSo = mauSo * phanSoNhan.mauSo;
                phanSoRutGon.RutGonPhanSo();

                Console.WriteLine($"Ket qua phep nhan: {phanSoRutGon.tuSo}/{phanSoRutGon.mauSo}");
            }
            public void ChiaPhanSo(PhanSo phanSoChia)
            {
                //Phép chia là nhân nghịch đảo
                PhanSo phanSoRutGon = new PhanSo();
                phanSoRutGon.tuSo = tuSo * phanSoChia.mauSo;
                phanSoRutGon.mauSo = mauSo * phanSoChia.tuSo;
                phanSoRutGon.RutGonPhanSo();

                Console.WriteLine($"Ket qua phep chia: {phanSoRutGon.tuSo}/{phanSoRutGon.mauSo}");
            }
            public float TimUCLN(float soThuNhat, float soThuHai)
            {
                //Tìm UCLN nên loại cần phải chuyển thành số dương
                soThuNhat = soThuNhat < 0 ? soThuNhat * -1 : soThuNhat;
                soThuHai = soThuHai < 0 ? soThuHai * -1 : soThuHai;

                while (soThuNhat > 0 && soThuHai > 0)
                {
                    if (soThuNhat >= soThuHai)
                        soThuNhat -= soThuHai;
                    else
                        soThuHai -= soThuNhat;
                }
                return soThuNhat + soThuHai;
            }
            public void RutGonPhanSo()
            {
                float UCLN = TimUCLN(tuSo, mauSo);
                tuSo = tuSo / UCLN;
                mauSo = mauSo / UCLN;
            }
        }
        public void GiaiBai23()
        {
            Console.Write("Nhap tu so phan so 1 (Tử số và mẫu số cách nhau bởi khoảng trắng): ");
            string inputPhanSoMot = Console.ReadLine();
            PhanSo phanSoMot = new PhanSo(float.Parse(inputPhanSoMot.Split(" ")[0]), float.Parse(inputPhanSoMot.Split(" ")[1]));

            Console.Write("Nhap tu so phan so 2 (Tử số và mẫu số cách nhau bởi khoảng trắng): ");
            string inputPhanSoHai = Console.ReadLine();
            PhanSo phanSoHai = new PhanSo(float.Parse(inputPhanSoHai.Split(" ")[0]), float.Parse(inputPhanSoHai.Split(" ")[1]));

            phanSoMot.CongPhanSo(phanSoHai);
            phanSoMot.TruPhanSo(phanSoHai);
            phanSoMot.NhanPhanSo(phanSoHai);
            phanSoMot.ChiaPhanSo(phanSoHai);
        }
    }
}
