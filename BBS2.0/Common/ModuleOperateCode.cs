using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BBS2._0.Common
{
    public enum ModuleOperateCode
    {
        [Description("新增")]
        Add1,
        [Description("编辑")]
        Eidt1,
        [Description("查询")]
        Search1,
        [Description("详情")]
        Detail1,
        [Description("删除")]
        Delete1,
        //以下是整理后的权限编码
        Register,
        Update,
        Del,
        Detail,
        Query,
        Login,
        Logout,
        Setting,
    }
}