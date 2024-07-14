using BE_2505.Common.Validate;
using BE_2505.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.Buoi14.ClassDB;

namespace BE_2505.Buoi14.Validate
{
    public class ValidateData
    {
        BE_2505.Common.ValidateData validateData = new Common.ValidateData();
        public ReturnData ValidateProductCategoryInput(ProductCategory product_Category)
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
        public ReturnData ValidateProductInput(Product product)
        {
            ReturnData returnData = new ReturnData();
            if (product == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            if (!validateData.PassCheckIputData<int>(product.CategoryID.ToString()))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "CategoryID không hợp lệ";
                return returnData;
            }
            if (!validateData.PassCheckIputData<string>(product.ProductName))
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "ProductName không hợp lệ";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
        public ReturnData ValidateProductGroupInput(ProductGroup productGroup)
        {
            ReturnData returnData = new ReturnData();
            if (productGroup == null)
            {
                returnData.ResponseCode = -1;
                returnData.ResponseMessage = "Dữ liệu đầu vào chưa được khởi tạo";
                return returnData;
            }
            returnData.ResponseCode = 1;
            return returnData;
        }
    }
}
