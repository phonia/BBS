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
    /// 每日签到 实体类
    /// </summary>
    public partial class DailySignature:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 连续累计
        /// </summary>
        public Int32 AccumulativeTotal { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public Int32 Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public Int32 Month { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        public Int32 Day { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
