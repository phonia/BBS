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
    /// 领域服务 实体类
    /// </summary>
    public partial class Service:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 全名
        /// </summary>
        public String FullName { get; set; }
        /// <summary>
        /// 程序集
        /// </summary>
        public String Assembly { get; set; }

        /// <summary>
        /// 导航属性领域服务
        /// </summary>
        public IList<ServiceMethod> Methods { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
