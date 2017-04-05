using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using BBS2._0.Permission;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface ISectionService
    {
        [ControlPermission("SectionManagement",ModuleOperateCode.Register.ToString())]
        bool RegisterSecion(String title, String description);

        [ControlPermission("SectionManagement", ModuleOperateCode.Update.ToString())]
        bool UpdateSection(Int32 id, String title, String description);

        [ControlPermission("SectionManagement", ModuleOperateCode.Del.ToString())]
        bool UnRegisterSection(Int32 id);

        [ControlPermission("SectionManagement", ModuleOperateCode.Detail.ToString())]
        SectionDTO GetById(Int32 id);

        [ControlPermission("SectionManagement", ModuleOperateCode.Query.ToString())]
        List<SectionDTO> GetAll();
    }
}