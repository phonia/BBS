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
    /// 领域服务方法 实体类
    /// </summary>
    public partial class ServiceMethod:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 所属服务
        /// </summary>
        public Int32 ServiceId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public String Name { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
