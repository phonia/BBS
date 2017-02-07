using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Simple.Models;

namespace Simple.Repository
{
    public class UserRepository : EFRepository<User,Int32>,IUserRepository
    {
    }
}