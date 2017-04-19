using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            if (types != null&&types.Count()>0)
            {
                foreach (var service in types)
                {
                    if (service.GetInterfaces().Contains(typeof(IDomainService)))
                    {
                        //TODO
                        MethodInfo[] methodInfos= service.GetMethods();
                        if (methodInfos != null && methodInfos.Count() > 0)
                        {
                            foreach (var type in methodInfos)
                            {

                            }
                        }
                    }
                }
            }
        }

        public void ReInitDataBase()
        { }

        #endregion
    }
}
