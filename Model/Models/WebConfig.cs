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
    /// 网站配置 实体类
    /// </summary>
    public partial class WebConfig:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 基本信息--网站名称
        /// </summary>
        public String WebName { get; set; }

        /// <summary>
        /// 基本信息--网站地址
        /// </summary>
        public String WebDomain { get; set; }

        /// <summary>
        /// 系统登陆日志保留时间--0=无限制，N（数字）= X月
        /// </summary>
        public Int32 LoginLogReserveTime { get; set; }

        /// <summary>
        /// 系统操作日志保留时间--0=无限制，N（数字）= X月
        /// </summary>
        public Int32 UseLogReserveTime { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
