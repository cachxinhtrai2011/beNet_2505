using BE_2505.Common.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2505.DataAccess.DAL
{
    public interface ISignIn
    {
        ReturnData SignIn(string userName, string passWord);
    }
}
