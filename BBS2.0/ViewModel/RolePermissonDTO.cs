using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class RolePermissonDTO
    {
        public Int32 Id { get; set; }
        public Int32? ModuleId { get; set; }
        public Int32? OperateId { get; set; }
        public String ModuleName { get; set; }
        public String OperateName { get; set; }
        public String KeyCode { get; set; }
        public bool IsOwned { get; set; }
        public bool IsModule { get; set; }
        public Int32? ParentId { get; set; }
        public List<RolePermissonDTO> children { get; set; }//children 首字母大写会不会受影响...

        /// <summary>
        /// 从数据库读取的角色权限 在组织成树形结构时，非叶子节点无法标记是否用权限（用于全选/全不选），需要调用此方法设置
        /// </summary>
        /// <returns></returns>
        public RolePermissonDTO Extension() {
            if (IsModule && children != null && children.Count > 0)
            {
                bool flag = true;
                foreach (var item in children)
                {
                    item.Extension();
                    if (!item.IsOwned)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) this.IsOwned = true;
            }
            return this;
        }
    }
}