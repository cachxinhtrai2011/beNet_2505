using BE_2505.Common.Validate;
using BE2505.DataAccess.DAL;
using BE2505.DataAccess.DTO;
using BE2505.DataAccess.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2505.DataAccess.DALImplement
{
    public class SignInManager : ISignIn
    {
        SignInDbContext signInDbContext = new SignInDbContext();
        public ReturnData SignIn(string userName, string passWord)
        {
            ReturnData returnData = new ReturnData();
            var result = new List<SignIn>();
            try
            {
                result = signInDbContext.SignIns.ToList();
                if(result.Where(x => x.userName == userName && x.password == passWord).ToList().Count() > 0)
                {
                    returnData.ResponseCode = 1;
                    returnData.ResponseMessage = "Đăng nhập thành công";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi rồi: {ex}");
                Environment.Exit(1);
            }
            return returnData;
        }
    }
}
