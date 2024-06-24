using BE_2505.Common.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi8.Bai1
{
    public class ValidateDataInsert
    {
        BE_2505.Common.Validate.ReturnData ReturnData = new Common.Validate.ReturnData();
        BE_2505.Common.ValidateData validateData = new Common.ValidateData();
        public ReturnData KiemTraDauVaoSinhVien(SinhVien sinhVien)
        {
            ReturnData returnData = new ReturnData();
            if(sinhVien == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(sinhVien.Ten))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(sinhVien.GioiTinh))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Giới tính không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<int>(sinhVien.Tuoi.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tuổi không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<float>(sinhVien.DiemHoa.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Điểm Hóa không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<float>(sinhVien.DiemLy.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Điểm Lý không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<float>(sinhVien.DiemToan.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Điểm Toán không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
        public ReturnData KiemTraKhiNhapSinhVien(string Ten, string GioiTinh, string Tuoi, string DiemLy, string DiemHoa, string DiemToan)
        {
            ReturnData returnData = new ReturnData();
            if (!validateData.PassCheckIputData<string>(Ten))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(GioiTinh))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Giới tính không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<int>(Tuoi))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tuổi không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<float>(DiemLy))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Điểm Hóa không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<float>(DiemHoa))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Điểm Lý không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<float>(DiemToan))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Điểm Toán không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
    }
}
