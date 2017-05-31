using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel
{
    public class ModuleMenuTreeGridDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 用于TreeGrid的Id
        /// </summary>
        public Int32 TreeId { get; set; }

        /// <summary>
        /// 目录名
        /// </summary>
        public String MenuName { get; set; }

        /// <summary>
        /// 目录编码
        /// </summary>
        public String MenuCode { get; set; }

        /// <summary>
        /// 目录是否可见
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// 是否是页面
        /// </summary>
        public bool IsPage { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public String URL { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public Int32 ParentId { get; set; }

        /// <summary>
        /// 目录类型
        /// </summary>
        public MenuTypeDTO MenuType { get; set; }

        public List<ModuleMenuTreeGridDTO> children { get; set; }

    }
}
