using BE_2505.Common.Validate;
using BE_2505.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.Buoi13.ClassDB;

namespace BE_2505.Buoi13.Validate
{
    public class ValidateData
    {
        BE_2505.Common.ValidateData validateData = new Common.ValidateData();
        public ReturnData ValidateProductCategoryInput(Product_Category product_Category)
        {
            ReturnData returnData = new ReturnData();
            if (product_Category == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product_Category.CategoryName))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Tên không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
        public ReturnData ValidateProductDetailInput(Product_Detail product_Detail)
        {
            ReturnData returnData = new ReturnData();
            if (product_Detail == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            if (!validateData.PassCheckIputData<int>(product_Detail.CategoryID.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "CategoryID không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product_Detail.ProductName))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ProductName không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
        public ReturnData ValidateProductSettingInput(Product_Settings product_Settings)
        {
            ReturnData returnData = new ReturnData();
            if (product_Settings == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            if (!validateData.PassCheckIputData<int>(product_Settings.ProductID.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ProductID không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<decimal>(product_Settings.RAM.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "RAM không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product_Settings.RAMUnit))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "RAMUnit không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product_Settings.ScreenUnit))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ScreenUnit không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<decimal>(product_Settings.ScreenWidth.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ScreenWidth không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<decimal>(product_Settings.Price.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Price không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
    }
}
