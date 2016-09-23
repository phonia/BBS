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
    /// 回复状态 枚举类
    /// </summary>
    public enum ReplyState
    {

        /// <summary>
        /// 回复状态 通常状态
        /// </summary>
        [Description("通常状态")]
        Common,

        /// <summary>
        /// 回复状态 最佳答案
        /// </summary>
        [Description("最佳答案")]
        BestChoice,

        /// <summary>
        /// 回复状态 屏蔽状态
        /// </summary>
        [Description("屏蔽状态")]
        Abandon
    }
}
