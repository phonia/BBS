using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Model;
using Services.Interface;

namespace Services.Implementation
{
    public class UserService:IUserService
    {
        private IUnitOfWork _unitOfWork = null;
        private IUserRepository _userRepository = null;

        public UserService(IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;

            this._userRepository.UnitOfWork = unitOfWork;
        }

        #region IUserService 成员

        public bool Login(string name, string password)
        {
            return true;
        }

        public bool Logout(string accountId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
