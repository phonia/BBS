using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BBS2._0.Common
{
    public enum ModuleOperateCode
    {
        //以下是整理后的权限编码
        Register,//c
        Create,
        Add,

        Update,//u
        Eidt,
        Setting,

        Del,//r
        Remove,

        Detail,//d
        Query,
        Search,

        Login,//f
        Logout,

    }
}