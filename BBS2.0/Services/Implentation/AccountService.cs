using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;
using BBS2._0.ViewModel;
using Infrastructure;
using BBS2._0.Common;

namespace BBS2._0.Services
{
    public class AccountService:IAccountService
    {
        private ISysRoleRepository _roleRepository = null;
        private IAccountRepository _accountRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public AccountService(IUnitOfWork unitOfWork, 
            IAccountRepository accountRepository,ISysRoleRepository roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._accountRepository = accountRepository;
            this._roleRepository = roleRepository;

            this._roleRepository.UnitOfWork = unitOfWork;
            this._accountRepository.UnitOfWork = unitOfWork;
        }

        #region IAccountService 成员

        public AccountDTO Login(string name, string password)
        {
            Account account = _accountRepository.GetFilter(it => it.Name.Equals(name) && it.Password.Equals(password)).FirstOrDefault();
            if (account != null)
                return account.MapperTo<Account, AccountDTO>();
            else
                throw new DomainException("登录失败");
        }

        public bool Logout(int id)
        {
            throw new NotImplementedException();
        }

        public AccountDTO RegisterAccount(ViewModel.AccountDTO accountDto)
        {
            Account account = accountDto.MapperTo<AccountDTO, Account>();
            account.AccountType = AccountType.Register;
            account.Role = _roleRepository.GetFilter(it => it.Name == Constant.ROLE_ANONYMOUS_EN).FirstOrDefault();//刚注册的用户设置为匿名角色
            //验证数据是否正确
            if (_accountRepository.GetFilter(it => it.Name.Equals(accountDto.Name)).FirstOrDefault() != null)
                throw new DomainException(Constant.ACCOUNT_NAME_REPEATED);
            _accountRepository.Add(account);
            _unitOfWork.Commit();

            return _accountRepository.Select(it => it.Name.Equals(accountDto.Name), it => new AccountDTO()
            {
                Id = it.Id,
                Age=it.Age,
                Email=it.Email,
                Name=it.Name,
                Password=it.Password,
                Sex=it.Sex,
                Tel=it.Tel,
                RoleId=it.Role.Id,
                RoleName=it.Role.Name
            }).First();
        }

        public AccountDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ViewModel.AccountDTO GetByName(string name)
        {
            AccountDTO account = _accountRepository.Select(it => it.Name.Equals(name), it => new AccountDTO()
            {
                Id = it.Id,
                Age = it.Age,
                Email = it.Email,
                Name = it.Name,
                Password = it.Password,
                Sex = it.Sex,
                Tel = it.Tel,
                RoleId = it.Role.Id,
                RoleName = it.Role.Name
            }).FirstOrDefault();
            if (account == null) throw new DomainException(Constant.ACCOUNT_NAME_NOTFOUND);
            return account;
        }

        public List<AccountDTO> GetAllAccount()
        {
            //System.Linq.Expressions.Expression<Func<Account,AccountDTO>> s=it=>null;
            return _accountRepository.Select(it => true, it => new AccountDTO()
            {
                Id = it.Id,
                Age=it.Age,
                Email=it.Email,
                Name=it.Name,
                Password=it.Password,
                RoleId=it.Role.Id,
                RoleName=it.Role.Name,
                Sex=it.Sex,
                Tel=it.Tel
            }).ToList();
        }

        #endregion
    }
}