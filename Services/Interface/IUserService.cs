using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interface
{
    public interface IUserService:IDomainService
    {
        bool Login(String name, String password);
        bool Logout(String accountId);
    }
}
