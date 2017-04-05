using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.Permission
{
    public interface Permission
    {

    }

    public class ControlPermissionAttribute :Attribute,Permission
    {
        public String ModuleCode { get; private set; }
        public String OPerateCode { get; private set; }

        public ControlPermissionAttribute(String moduleCode, String operateCode)
        {
            this.OPerateCode = operateCode;
            this.ModuleCode = moduleCode;
        }
    }

    public class DataPermissiom : Attribute, Permission
    { }
}