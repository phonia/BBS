using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Services.Interface;

namespace Services.Implementation
{
    public class SysService:ISysService
    {
        private IUserRepository _userRepository = null;

        public SysService()
        { }

        #region ISysService 成员

        public void InitDataBase()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
