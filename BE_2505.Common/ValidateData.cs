using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public class ValidateData
    {
        public bool PassCheckIputData<T>(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            if (typeof(T) == typeof(int))
            {
                int value;
                if (!int.TryParse(input, out value))
                {
                    return false;
                }
            }
            else if (typeof(T) == typeof(float))
            {
                float value;
                if (!float.TryParse(input, out value))
                {
                    return false;
                }
            }
            else if (typeof(T) == typeof(double))
            {
                double value;
                if (!double.TryParse(input, out value))
                {
                    return false;
                }
            }
            else if (typeof(T) == typeof(decimal))
            {
                decimal value;
                if (!decimal.TryParse(input, out value))
                {
                    return false;
                }
            }
            else if (typeof (T) == typeof(string))
            {
                if(input.Length <= 0 || input.Length > 5000)
                {
                    Console.WriteLine("Độ dài chuỗi không hợp lệ");
                    return false;
                }
                if (!ContainsSpecialCharacters(input))
                {
                    Console.WriteLine("Chuỗi chứa ký tự đặc biệt. Vui lòng kiểm tra lại!");
                    return false;
                }
            }

            return true;
        }
        public bool ContainsSpecialCharacters(string input)
        {
            // Chỉ cho phép các ký tự chữ và số
            string pattern = @"^[a-zA-Z0-9]*$";
            return Regex.IsMatch(input, pattern);
        }
        public bool CheckPositiveNumber(int input)
        {
            if(input < 0 || input > 100)
            {
                return false;
            }
            return true;
        }
    }
}
