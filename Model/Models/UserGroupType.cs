/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Infrastructure;

namespace Model
{
    /// <summary>
    ///  枚举类
    /// </summary>
    public enum UserGroupType
    {

        /// <summary>
        ///  普通用户
        /// </summary>
        [Description("普通用户")]
        RegisterUser,

        /// <summary>
        ///  管理员
        /// </summary>
        [Description("管理员")]
        Manager,

        /// <summary>
        ///  后台管理员
        /// </summary>
        [Description("后台管理员")]
        SuperManager,

        /// <summary>
        ///  受限用户
        /// </summary>
        [Description("受限用户")]
        RestrictedUser
    }
}
