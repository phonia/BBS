using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Constant
    {
        //用户角色等
        public const String DEFAULT_USERGROUP = "默认用户组";
        public const String ANONYMOUS_ROLE = "匿名角色";
        public const String MANAGER_ROLE = "管理员角色";
        public const String ANONYMOUS_USER = "Anony";//匿名用户
        public const String SUPERMANAGER_USER = "Admin";//管理员用户

        //ajax返回值中的message
        public const String SUCCESS_MESSAGE = "成功";
        public const String FAILED_MESSAGE = "失败";

        //session中的key
        public const String LoginUser = "LoginUser";
    }
}
