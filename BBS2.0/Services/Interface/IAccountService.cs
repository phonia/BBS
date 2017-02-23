using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IAccountService
    {
        AccountDTO Login(String name, String password);
        bool Logout(Int32 id);
        AccountDTO RegisterAccount(AccountDTO accountDto);
        AccountDTO GetById(Int32 Id);
        AccountDTO GetByName(String name);
    }
}
