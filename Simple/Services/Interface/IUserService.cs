using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.ViewModel;

namespace Simple.Services
{
    public interface IUserService
    {
        bool RegisterUser(UserDTO userDTO);
        bool CancelUser(Int32 userId);
        bool Login(String account, String password);

        bool UpdateUser(Int32 userId, UserDTO userDTO);

        UserDTO GetById(Int32 id);
        UserDTO GetByAccount(String account);
        List<UserDTO> GetAllAccount();
    }
}