using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;
using BBS2._0.ViewModel;
using Infrastructure;
using BBS2._0.Common;
using Unities;

namespace BBS2._0.Services
{
    public class ModuleService:IModuleService
    {
        private ISysModuleRepository _moduleRepository = null;
        private ISysModuleOperateRepository _moduleOperateRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public ModuleService(ISysModuleRepository sysModuleRepository,ISysModuleOperateRepository sysModuleOperateRepository,
            IUnitOfWork unitOfWork)
        {
            this._moduleRepository = sysModuleRepository;
            this._moduleOperateRepository = sysModuleOperateRepository;

            this._unitOfWork = unitOfWork;
            this._moduleRepository.UnitOfWork = unitOfWork;
            this._moduleOperateRepository.UnitOfWork = unitOfWork;
        }

        #region IModuleService 成员

        public bool RegisterModule(string name, string moduleCode, string description, bool isLeaf, String parentId)
        {
            SysModule module = new SysModule()
            {
                Name = name,
                //Url = url,
                ModuleCode=moduleCode,
                Description = description,
                IsLeaf = isLeaf,
            };
            if (Convert.ToInt32(parentId) > 0) module.ParentId = Convert.ToInt32(parentId);
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
                ModuleCode=it.ModuleCode,
                ParentId=it.ParentId!=null?(Int32)it.ParentId:0
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
                ModuleCode=it.ModuleCode,
                ParentId = it.ParentId != null ? (Int32)it.ParentId : 0
            }).FirstOrDefault();
            if (ret == null) throw new DomainException("");
            return ret;
        }

        public List<ModuleOperateDTO> GetModuleOperatesByModuleId(Int32 moduleId)
        {
             return _moduleOperateRepository.Select(it => it.ModuleId == moduleId, it => new ModuleOperateDTO()
            {
                Id = it.Id,
                IsValid=it.IsValid,
                KeyCode=it.KeyCode,
                ModuleId=it.ModuleId,
                OperateCode=((ModuleOperateCode)it.OperateCode).ToString(),
                OperateName=it.Name,
                ModuleName=it.Module.Name
            }).ToList();

            //List<ModuleOperateDTO> list=new List<ModuleOperateDTO>();
            //foreach (var item in ret)
            //{
            //    ModuleOperateDTO mod = new ModuleOperateDTO()
            //    {
            //        Id = item.Id,
            //        IsValid = item.IsValid,
            //        KeyCode = item.KeyCode,
            //        ModuleId = item.ModuleId,
            //        OperateCode=((ModuleOperateCode)item.OperateCode).ToString(),
            //        OperateName = ((ModuleOperateCode)item.OperateCode).GetDescriptionOrNull()
            //    };
            //    list.Add(mod);
            //}
            //return list;
        }

        public bool RegisterModuleOperate(String name, String url, bool isValid, Int32 moduelId)
        {
            //Int32 count = _moduleOperateRepository.GetFilter(it => it.ModuleId == moduelId).Count();
            //SysModuleOperate moduleOperate = new SysModuleOperate()
            //{
            //    IsValid = isValid,
            //    KeyCode=moduelId.ConvertDecimalToHex(4)+(count+1).ConvertDecimalToHex(4),
            //    ModuleId=moduelId,
            //    Name=name,                
            //    Url=url//地址不能重复
            //};
            //_moduleOperateRepository.Add(moduleOperate);
            //_unitOfWork.Commit();
            return true;
        }
        #endregion
    }
}