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
    /// 导航目录 实体类
    /// </summary>
    public partial class Navagation:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 导航名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public Int32 Level { get; set; }

        /// <summary>
        /// 菜单目录
        /// </summary>
        public bool IsMenu { get; set; }

        /// <summary>
        /// 功能页面
        /// </summary>
        public bool IsPage { get; set; }

        /// <summary>
        /// 前端显示
        /// </summary>
        public bool IsDisplay { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public Navagation Parent { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Navagation> Children { get; set; }
    }
}
