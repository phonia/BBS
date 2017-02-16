using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using Simple.Common;

namespace Simple.Models
{
    public class User:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Account { get; set; }
        public String Password { get; set; }
        public Sex Sex { get; set; }
        public AccountType AcountType { get; set; }
        public Int32 Age { get; set; }
        public String Tel { get; set; }
        public String Email { get; set; }

        protected override void Validate()
        {
            if (Age <= 0 || Age >= 150) base.AddBrokenRule(new BusinessRule() { Property = "Age", Rule = "Age between 0 and 150" });
            //验证其他的参数
        }

        public void Update(User user)
        {

        }
    }
}