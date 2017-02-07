using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Common;

namespace Simple.ViewModel
{
    public class UserDTO
    {
        public Int32 Id { get; set; }
        public String Account { get; set; }
        public String Password { get; set; }
        public AccountType AccountType { get; set; }
        public Sex Sex { get; set; }
        public Int32 Age { get; set; }
        public String Tel { get; set; }
        public String Email { get; set; }
    }
}