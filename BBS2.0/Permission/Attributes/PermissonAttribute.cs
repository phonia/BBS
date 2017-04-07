using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;

namespace BBS2._0.Permission
{
    public interface Permission
    {

    }

    public class ControlPermissionAttribute :Attribute,Permission
    {
        public String ModuleCode { get; private set; }
        public ModuleOperateCode OPerateCode { get; private set; }

        public ControlPermissionAttribute(String moduleCode, ModuleOperateCode operateCode)
        {
            this.OPerateCode = operateCode;
            this.ModuleCode = moduleCode;
        }
    }
}