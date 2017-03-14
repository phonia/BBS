using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IModuleService
    {
        bool RegisterModule(String name,String url,String description,bool isLeaf,Int32? parentId=null);
        //bool SaveModule(Int32 Id);
        bool RemoveModule(Int32 Id);
        bool RemoveModules(List<Int32> ids);

        List<ModuleDTO> GetAllModuels();
        ModuleDTO GetModuleById(Int32 Id);
    }
}
