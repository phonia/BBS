﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Services.Interface
{
    public interface IModuleMenuService:IDomainService
    {
        List<ModuleMenuDTO> GetBackStageMenu(int id=-1);

        List<ModuleMenuDTO> GetAllMenu();
    }
}
