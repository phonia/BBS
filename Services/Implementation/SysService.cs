using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Common;
using Infrastructure;
using Model;
using Services.Interface;

namespace Services.Implementation
{
    public class SysService:ISysService
    {
        private IUnitOfWork _unitOfWork = null;
        private IUserRepository _userRepository = null;
        private IWebConfigRepository _webConfigRepository = null;
        private IServiceRepository _serviceRepository = null;
        private IServiceMethodRepository _serviceMethodRepository = null;

        public SysService(IWebConfigRepository webCoifigRepository,IUserRepository userRepository,
            IServiceRepository serviceRepository,IServiceMethodRepository serviceMethodRepository,
            IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._webConfigRepository = webCoifigRepository;
            this._serviceRepository = serviceRepository;
            this._serviceMethodRepository = serviceMethodRepository;

            this._serviceRepository.UnitOfWork = unitOfWork;
            this._serviceMethodRepository.UnitOfWork = unitOfWork;
            this._userRepository.UnitOfWork = unitOfWork;
            this._webConfigRepository.UnitOfWork = unitOfWork;
            this._unitOfWork = unitOfWork;
        }

        #region ISysService 成员

        public void InitDataBase()
        {
            if (_webConfigRepository.GetFilter(it => it.IsInitialed == true).FirstOrDefault() != null) return;
            _webConfigRepository.Add(new WebConfig() { IsInitialed = true });

            #region 领域服务
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            if (types != null&&types.Count()>0)
            {
                foreach (var service in types)
                {
                    if (service.GetInterfaces().Contains(typeof(IDomainService)))
                    {
                        //TODO
                        Service s = new Service()
                        {
                            Assembly = Assembly.GetExecutingAssembly().FullName
                        };
                        MethodInfo[] methodInfos= service.GetMethods();
                        if (methodInfos != null && methodInfos.Count() > 0)
                        {
                            foreach (var type in methodInfos)
                            {
                                ServiceMethod sm = new ServiceMethod()
                                {
                                    Name = type.Name
                                };
                                if (s.Methods == null) s.Methods = new List<ServiceMethod>();
                                s.Methods.Add(sm);
                            }
                        }
                        _serviceRepository.Add(s);
                    }
                }
            }
            #endregion

            #region 用户、角色

            UserGroup ug1 = new UserGroup() { Name =Constant.DEFAULT_USERGROUP };
            Role r1 = new Role() { Name = Constant.ANONYMOUS_ROLE, RoleType = RoleType.SysBuiltIn };
            Role r2 = new Role() { Name = Constant.MANAGER_ROLE, RoleType = RoleType.SysBuiltIn };
            User u1 = new User()
            {
                AccountName = Constant.SUPERMANAGER_USER,
                AccountPassword = Constant.SUPERMANAGER_USER,
                Role = r2,
                AccountInfo = new AccountInfo() { LoginCount = 0, LoginDate = DateTime.Today, LoginIP = "192.168.5.108", RegisterDate = DateTime.Today, RegisterIp = "192.168.5.108" },
                UserGroup = ug1,
                PersonalInfo = new PersonalInfo() { Age = 28, Email = "woshiorpheus@126.com", Fax = "34510996", Name = "HY", Phone = "15975455335", Sex = Sex.Male, Tel = "87072280" }
            };

            User u2 = new User()
            {
                AccountName = Constant.SUPERMANAGER_USER,
                AccountPassword = Constant.SUPERMANAGER_USER,
                Role = r1,
                AccountInfo = new AccountInfo() { LoginCount = 0, LoginDate = DateTime.Today, LoginIP = "192.168.5.108", RegisterDate = DateTime.Today, RegisterIp = "192.168.5.108" },
                UserGroup = ug1,
                PersonalInfo = new PersonalInfo() { Age = 28, Email = "woshiorpheus@126.com", Fax = "34510996", Name = "POLAN", Phone = "15975455335", Sex = Sex.Male, Tel = "87072280" }
            };
            _userRepository.Add(u1);
            _userRepository.Add(u2);

            #endregion

            _unitOfWork.Commit();
        }

        public void ReInitDataBase()
        { }

        #endregion
    }
}
