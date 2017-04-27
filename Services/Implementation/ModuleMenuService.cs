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

        public List<ModuleMenuDTO> GetTopMenu()
        {
            var ret = this._moduleMenuRepository.Select(it => it.IsDeleted == false && it.IsEnable == true && it.IsVisible == true && it.IsPage == false && it.ParentId == null,
                ModuleMenuMapping.ConvertToDTO());
            return ret.ToList();
        }

        public TreeDTO GetChildMenuTreeByTopId()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
