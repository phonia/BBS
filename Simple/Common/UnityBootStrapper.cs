using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Repository;
using Simple.Models;
using Simple.Repository;
using Simple.Services;

namespace Simple.Common
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
            UnityContainer.RegisterType<IUserRepository, UserRepository>();
            UnityContainer.RegisterType<ISectionRepository, SectionRepository>();
            UnityContainer.RegisterType<IPostRepository, PostRepository>();

            //服务接口
            UnityContainer.RegisterType<IUserService, UserService>();
            UnityContainer.RegisterType<ISectionService, SectionService>();
            UnityContainer.RegisterType<IPostService, PostService>();
        }
    }
}
