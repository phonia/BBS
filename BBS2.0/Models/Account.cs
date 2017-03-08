using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using Infrastructure;

namespace BBS2._0.Models
{
    public class Account:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public Sex Sex { get; set; }
        public AccountType AccountType { get; set; }
        public Int32 Age { get; set; }
        public String Tel { get; set; }
        public String Email { get; set; }
        public Int32 RoleId { get; set; }

        public SysRole Role { get; set; }


        protected override void Validate()
        {
            //数据验证
            base.Validate();
            //this.AddBrokenRule(new BusinessRule() { Property = "Name", Rule = "Repeated" });
        }
    }
}