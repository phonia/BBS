﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services.Interface
{
    public interface IUserService:IDomainService
    {
        UserDTO Login(String name, String password);
        bool Logout(String accountId);
    }
}
