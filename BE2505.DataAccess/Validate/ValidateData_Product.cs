using BE_2505.Common;
using BE_2505.Common.Validate;
using BE2505.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2505.DataAccess.Validate
{
    public class ValidateData_Product
    {
        ValidateData validateData = new ValidateData();
        public ReturnData ValidateProductInput(Product_Practice product_Practice)
        {
            ReturnData returnData = new ReturnData();
            if (product_Practice == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product_Practice.PracticeName))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product_Practice.PracticeDesc))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
    }
}
