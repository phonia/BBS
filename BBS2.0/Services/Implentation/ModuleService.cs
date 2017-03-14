using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;
using BBS2._0.ViewModel;
using Infrastructure;

namespace BBS2._0.Services
{
    public class ModuleService:IModuleService
    {
        private ISysModuleRepository _moduleRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public ModuleService(ISysModuleRepository sysModuleRepository, IUnitOfWork unitOfWork)
        {
            this._moduleRepository = sysModuleRepository;
            this._unitOfWork = unitOfWork;
            this._moduleRepository.UnitOfWork = unitOfWork;
        }

        #region IModuleService 成员

        public bool RegisterModule(string name, string url, string description, bool isLeaf, Int32? parentId = null)
        {
            SysModule module = new SysModule()
            {
                Name = name,
                Url = url,
                Description = description,
                IsLeaf = isLeaf,
                ParentId = parentId
            };
            this._moduleRepository.Add(module);
            this._unitOfWork.Commit();
            return true;
        }

        public bool RemoveModule(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveModules(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public List<ModuleDTO> GetAllModuels()
        {
            return _moduleRepository.Select(it => true, it => new ModuleDTO()
            {
                Id = it.Id,
                Description=it.Description,
                IsLeaf=it.IsLeaf,
                Name=it.Name,
                Url=it.Url
            }).ToList();
        }

        public ModuleDTO GetModuleById(int Id)
        {
            var ret= _moduleRepository.Select(it => it.Id == Id, it => new ModuleDTO()
            {
                Id = it.Id,
                Description = it.Description,
                IsLeaf = it.IsLeaf,
                Name = it.Name,
                Url = it.Url
            }).FirstOrDefault();
            if (ret == null) throw new DomainException("");
            return ret;
        }

        #endregion
    }
}