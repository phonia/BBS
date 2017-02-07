using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using Simple.Models;
using Simple.ViewModel;
using Simple.Common;

namespace Simple.Services
{
    /**
     * 1、没有做参数验证
     * 2、没有做异常处理
     * 3、没有做缓存处理
     * 4、没有做日志处理
     * **/
    public class UserService:IUserService
    {
        private IUserRepository _userRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public UserService(IUnitOfWork unitOfwork,IUserRepository userRepository)
        {
            this._unitOfWork = unitOfwork;
            this._userRepository = userRepository;

            this._userRepository.UnitOfWork = unitOfwork;
        }

        #region IUserService 成员

        public bool RegisterUser(UserDTO userDTO)
        {
            User userRegister = userDTO.MapperTo<UserDTO, User>();
            if (this._userRepository.GetFilter(it => it.Account.Equals(userRegister.Account)).FirstOrDefault() != null) return false;

            _userRepository.Add(userRegister);
            _unitOfWork.Commit();
            return true;
        }

        public bool CancelUser(int userId)
        {
            if (this._userRepository.GetFilter(it => it.Id == userId).FirstOrDefault() == null) return false;

            _userRepository.RemoveNonCascaded(userId);
            _unitOfWork.Commit();
            return true;
        }

        public bool Login(string account, string password)
        {
            if (this._userRepository.GetFilter(it => it.Account.Equals(account) && it.Password.Equals(password)).FirstOrDefault() == null)
                return false;
            else
                return true;
        }

        public bool UpdateUser(int userId, UserDTO userDTO)
        {
            User userUpdating=this._userRepository.GetFilter(it => it.Id == userId).FirstOrDefault();
            if (userUpdating == null) return false;

            userUpdating.Update(userDTO.MapperTo<UserDTO, User>());
            _userRepository.Save(userUpdating);
            _unitOfWork.Commit();
            return true;
        }

        public UserDTO GetById(int id)
        {
            return _userRepository.GetByKey(id)
                .MapperTo<User, UserDTO>();
        }

        public UserDTO GetByAccount(string account)
        {
            User user = _userRepository.GetFilter(it => it.Account.Equals(account)).FirstOrDefault();
            if (user == null) return null;//进行错误处理 暂未完成
            return user.MapperTo<User, UserDTO>();
        }

        public List<UserDTO> GetAllAccount()
        {
            return _userRepository.GetAll()
                .MapperTo<User, UserDTO>()
                .ToList();
        }

        #endregion
    }
}