using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.Common
{
    public class Constant
    {
        public const String ACCOUNT_NAME_REPEATED = "重复的账户名";
        public const String ACCOUNT_NAME_NOTFOUND = "不存在的用户名";
        public const String ACCOUNT_NAME_ANONYMOUS_EN = "anonymous";
        public const String ACCOUNT_NAME_ANONYMOUS_CH = "匿名用户";
        public const String ACCOUNT_NOTFOUND = "不存在的用户";

        public const String SECTION_NOTFOUND = "不存在的版块";

        public const String ROLE_REPEATED = "重复的角色名";
        public const String ROLE_ACCOUNT_USED = "角色被用户使用";
        public const String ROLE_NOTFOUND = "不存在的角色";
        public const String ROLE_BUILTIN = "不允许删除内置角色";
        public const String ROLE_MANAGER_EN = "SuperRole";
        public const String ROLE_MANAGER_CH = "超级管理";
        public const String ROLE_ANONYMOUS_EN = "Anonymous";
        public const String ROLE_ANONYMOUS_CN = "匿名角色";

        public const String DATALENGTH_NOTEQUAL = "数据长度不一致";
    }
}