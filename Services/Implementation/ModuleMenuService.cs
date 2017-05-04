using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Model;
using Services.Interface;
using ViewModel;
using Services.Mapping;

namespace Services.Implementation
{
    public class ModuleMenuService:IModuleMenuService
    {
        private IModuleMenuRepository _moduleMenuRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public ModuleMenuService(IUnitOfWork unitOfWork, IModuleMenuRepository moduleMenuRepository)
        {
            this._moduleMenuRepository = moduleMenuRepository;
            this._unitOfWork = unitOfWork;

            this._moduleMenuRepository.UnitOfWork = unitOfWork;
        }

        #region IModuleMenuService 成员

        public List<ModuleMenuDTO> GetBackStageMenu(int id = -1)
        {
            if (id < 0)
            {
                var ret = this._moduleMenuRepository.Select(it => it.IsDeleted == false && it.IsEnable == true && it.IsVisible == true && it.IsPage == false && it.ParentId == null && it.MenuType == MenuType.BackStage,
                    ModuleMenuMapping.ConvertToDTO());
                return ret.ToList();
            }
            else
            {
                return this._moduleMenuRepository.Select(it => it.IsDeleted == false && it.IsEnable == true && it.IsVisible == true && it.IsPage == false 
                    &&(it.ParentId==id||it.Parent.ParentId==id||it.Parent.Parent.ParentId==id||it.Parent.Parent.Parent.ParentId==id)
                    && it.MenuType == MenuType.BackStage,
                    ModuleMenuMapping.ConvertToDTO())
                    .ToList();
            }
        }

        public List<ModuleMenuDTO> GetAllMenu()
        {
            return this._moduleMenuRepository.Select(it => it.IsDeleted == false, ModuleMenuMapping.ConvertToDTO()).ToList();
        }

        #endregion
    }
}
