using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Model;
using Repository;
using Services.Implementation;
using Services.Interface;

namespace BCP.WebUI.App_Start
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
            UnityContainer.RegisterType<IWebConfigRepository, WebConfigRepository>();
            UnityContainer.RegisterType<IUserRepository, UserRepository>();
            UnityContainer.RegisterType<IServiceRepository, ServiceRepository>();
            UnityContainer.RegisterType<IServiceMethodRepository, ServiceMethodRepository>();
            UnityContainer.RegisterType<IUserRepository, UserRepository>();
            UnityContainer.RegisterType<IModuleMenuRepository, ModuleMenuRepository>();


            //服务接口
            UnityContainer.RegisterType<ISysService, SysService>();
            UnityContainer.RegisterType<IUserService, UserService>();
            UnityContainer.RegisterType<IModuleMenuService, ModuleMenuService>();
            //UnityContainer.RegisterType<IAccountService, AccountService>(
            //                    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<PermissonValidateInterceptor>(),
            //    new InterceptionBehavior<CacheInterceptor>()
            //    );
            //UnityContainer.RegisterType<ISectionService, SectionService>(
            //                    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<PermissonValidateInterceptor>(),
            //    new InterceptionBehavior<CacheInterceptor>()
            //    );
            //UnityContainer.RegisterType<IPostService, PostService>(
            //                    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<PermissonValidateInterceptor>(),
            //    new InterceptionBehavior<CacheInterceptor>()
            //    );
            //UnityContainer.RegisterType<IReplyService, ReplyService>(
            //                    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<PermissonValidateInterceptor>(),
            //    new InterceptionBehavior<CacheInterceptor>()
            //    );
            //UnityContainer.RegisterType<IModuleService, ModuleService>(
            //                    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<PermissonValidateInterceptor>(),
            //    new InterceptionBehavior<CacheInterceptor>()
            //    );
            //UnityContainer.RegisterType<IRoleService, RoleService>(
            //                    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<PermissonValidateInterceptor>(),
            //    new InterceptionBehavior<CacheInterceptor>()
            //    );
        }
    }
}