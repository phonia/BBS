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
        private IAccountRepository _accountRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            this._unitOfWork = unitOfWork;
            this._accountRepository = accountRepository;

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
            //验证数据是否正确
            if (_accountRepository.GetFilter(it => it.Name.Equals(accountDto.Name)).FirstOrDefault() != null)
                throw new DomainException(Contant.ACCOUNT_NAME_REPEATED);
            _accountRepository.Add(account);
            _unitOfWork.Commit();
            return _accountRepository.GetFilter(it => it.Name.Equals(accountDto.Name))
                .First()
                .MapperTo<Account, AccountDTO>();
        }

        public AccountDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ViewModel.AccountDTO GetByName(string name)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}