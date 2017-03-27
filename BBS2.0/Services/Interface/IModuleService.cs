using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IModuleService
    {
        bool RegisterModule(String name, String moduleCode, String description, bool isLeaf, String parentId);
        //bool SaveModule(Int32 Id);
        bool RemoveModule(Int32 Id);
        bool RemoveModules(List<Int32> ids);
        List<ModuleDTO> GetAllModuels();
        ModuleDTO GetModuleById(Int32 Id);

        bool RegisterModuleOperate(String name, String url, bool isValid, Int32 moduelId);
        List<ModuleOperateDTO> GetModuleOperatesByModuleId(Int32 moduleId);
        List<ModuleOperateDTO> GetAllModuleOperate();
    }
}
