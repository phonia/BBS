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
    /// 个人信息 复合属性
    /// </summary>
    public partial class PersonalInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public Int32 Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public Byte[] Avatar { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public String NativePlace { get; set; }

        /// <summary>
        /// 通讯地址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public String PostCodes { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public String MailBox { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        public String Telephone { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public String Mobliephone { get; set; }

        /// <summary>
        /// 个人主页
        /// </summary>
        public String Page { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public String Signature { get; set; }
    }
}
