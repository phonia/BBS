using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    interface IModuleService
    {
        bool RegisterModule(ModuleDTO moduleDTO);
        //bool SaveModule(Int32 Id);

        List<ModuleDTO> GetAllModuels();
        ModuleDTO GetModuleById(Int32 Id);
        ModuleDTO GetModuleByName(String name);

    }
}
