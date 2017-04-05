using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;
using Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace BBS2._0.Permission
{
    public class PermissonValidateInterceptor : IInterceptionBehavior
    {
        //此处为何可以DI？无法理解
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }

        [Dependency]
        public ISysRoleRepository RoleRepository { get; set; }

        #region IInterceptionBehavior 成员

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            object[] attrs = input.MethodBase.GetCustomAttributes(false);
            foreach (var item in attrs)
            {
                if (item.GetType().GetInterfaces().Contains(typeof(Permission)))
                {
                    if (item.GetType().FullName.Equals(typeof(ControlPermissionAttribute).FullName))
                    {
 
                    }
                    else
                    { }
                }
            }
            //throw new NotImplementedException();
            return getNext()(input, getNext); 
        }

        public bool WillExecute
        {
            //get { throw new NotImplementedException(); }
            get { return true; }
        }

        #endregion
    }
}