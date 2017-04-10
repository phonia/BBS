using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using BBS2._0.Repository;
using BBS2._0.Models;
using BBS2._0.Services;
using BBS2._0.Permission;
using BBS2._0.Cache;

namespace BBS2._0.Common
{
    /// <summary>
    /// Unit配置类
    /// </summary>
    public class UnityBootStrapper
    {
        public IUnityContainer UnityContainer = new UnityContainer();

        public void Bindings()
        {
            UnityContainer.AddNewExtension<Interception>();
            UnityContainer.RegisterType<IUnitOfWork, EFUnitOfWork>();

            //仓储接口
            //UnityContainer.RegisterType<IUserRepository, UserRepository>();
            //UnityContainer.RegisterType<ISectionRepository, SectionRepository>();
            //UnityContainer.RegisterType<IPostRepository, PostRepository>();
            UnityContainer.RegisterType<IAccountRepository, AccountRepository>();
            UnityContainer.RegisterType<ISectionRepository, SectionRepository>();
            UnityContainer.RegisterType<IPostRepository, PostRepository>();
            UnityContainer.RegisterType<IReplyRepository, ReplyRepository>();
            UnityContainer.RegisterType<ISysRoleRepository, SysRoleRepository>();
            UnityContainer.RegisterType<ISysModuleRepository, SysModuleRepository>();
            UnityContainer.RegisterType<ISysFunctionRightRepository, SysFuntionRightRepository>();
            UnityContainer.RegisterType<ISysLogRepository, SysLogRepository>();
            UnityContainer.RegisterType<ISysExceptionRepository, SysExceptionRepository>();
            UnityContainer.RegisterType<ISysModuleOperateRepository, SysModuleOperateRepository>();

            //服务接口
            //UnityContainer.RegisterType<IUserService, UserService>();
            //UnityContainer.RegisterType<ISectionService, SectionService>();
            //UnityContainer.RegisterType<IPostService, PostService>();
            UnityContainer.RegisterType<IAccountService, AccountService>(
                                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PermissonValidateInterceptor>(),
                new InterceptionBehavior<CacheInterceptor>()
                );
            UnityContainer.RegisterType<ISectionService, SectionService>(
                                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PermissonValidateInterceptor>(),
                new InterceptionBehavior<CacheInterceptor>()
                );
            UnityContainer.RegisterType<IPostService, PostService>(
                                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PermissonValidateInterceptor>(),
                new InterceptionBehavior<CacheInterceptor>()
                );
            UnityContainer.RegisterType<IReplyService, ReplyService>(
                                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PermissonValidateInterceptor>(),
                new InterceptionBehavior<CacheInterceptor>()
                );
            UnityContainer.RegisterType<IModuleService, ModuleService>(
                                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PermissonValidateInterceptor>(),
                new InterceptionBehavior<CacheInterceptor>()
                );
            UnityContainer.RegisterType<IRoleService, RoleService>(
                                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<PermissonValidateInterceptor>(),
                new InterceptionBehavior<CacheInterceptor>()
                );
        }
    }
}
