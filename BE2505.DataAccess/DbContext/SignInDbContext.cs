using BE2505.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2505.DataAccess
{
    public class SignInDbContext : DbContext
    {
        public SignInDbContext() : base("name=BE2505_LuyenTap") { }
        public virtual DbSet<SignIn> SignIns { get; set; }
    }
}
