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
    /// 账户信息 复合属性
    /// </summary>
    public partial class AccountInfo
    {
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 注册IP
        /// </summary>
        public String RegisterIp { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public String LoginIP { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public Int32 LoginCount { get; set; }
    }
}
