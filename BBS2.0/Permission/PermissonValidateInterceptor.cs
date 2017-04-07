using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using BBS2._0.Models;
using BBS2._0.ViewModel;
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
        public ISysModuleOperateRepository ModuleOperateRepository { get; set; }

        [Dependency]
        public IAccountRepository AccountRepository { get; set; }

        [Dependency]
        public ISysRoleRepository RoleRepository { get; set; }

        [Dependency]
        public ISysFunctionRightRepository FunctionRightRepository { get; set; }

        #region IInterceptionBehavior 成员

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //throw new DomainException("异常测试！");
            object[] attrs = input.MethodBase.GetCustomAttributes(false);
            foreach (var item in attrs)
            {
                if (item.GetType().GetInterfaces().Contains(typeof(Permission)))
                {
                    if (item.GetType().FullName.Equals(typeof(ControlPermissionAttribute).FullName))
                    {
                        var attr = item as ControlPermissionAttribute;
                        this.ModuleOperateRepository.UnitOfWork = UnitOfWork;
                        var operate= ModuleOperateRepository.GetFilter(it => it.Module.ModuleCode.Equals(attr.ModuleCode) && it.OperateCode == attr.OPerateCode).FirstOrDefault();
                        if (operate == null) throw new DomainPermissionException("权限设置错误");
                        //HttpContext.Current.Session[""]
                        if (HttpContext.Current.Session[Constant.ACCOUNT_SESSION] == null)
                        {
                            throw new DomainPermissionException(Constant.ACCOUNT_NOTLOGIN);
                        }
                        else
                        {
                            var account = HttpContext.Current.Session[Constant.ACCOUNT_SESSION] as AccountDTO;
                            this.FunctionRightRepository.UnitOfWork = UnitOfWork;
                            var isPermission= FunctionRightRepository.GetFilter(it => it.RoleId == account.RoleId && it.KeyCode.Equals(operate.KeyCode)).FirstOrDefault();
                            if (isPermission == null)
                            {
                                throw new DomainPermissionException(Constant.ACCOUNT_NOTPERMISSION);
                            }
                        }
                    }
                }
            }
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