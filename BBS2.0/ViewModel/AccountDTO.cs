using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;

namespace BBS2._0.ViewModel
{
    public class AccountDTO
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public Sex Sex { get; set; }
        public Int32 Age { get; set; }
        public String Tel { get; set; }
        public String Email { get; set; }

        public Int32 RoleId { get; set; }
        public String RoleName { get; set; }
    }
}