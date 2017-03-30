using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using BBS2._0.Models;
using BBS2._0.ViewModel;
using Infrastructure;

namespace BBS2._0.Services
{
    public class RoleService:IRoleService
    {
        private ISysRoleRepository _roleRepository = null;
        private ISysModuleOperateRepository _moduleOperateRepository = null;
        private ISysModuleRepository _moduleRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public RoleService(ISysRoleRepository roleRepository,ISysModuleRepository moduleRepository,ISysModuleOperateRepository moduleOperateRepository,
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
            this._moduleOperateRepository = moduleOperateRepository;
            this._moduleRepository = moduleRepository;

            this._roleRepository.UnitOfWork = unitOfWork;
            this._moduleRepository.UnitOfWork = unitOfWork;
            this._moduleOperateRepository.UnitOfWork = unitOfWork;
        }

        #region IRoleService 成员

        public List<RoleDTO> GetAllRoles()
        {
            return _roleRepository.Select(it => true, it => new RoleDTO()
            {
                Id = it.Id,
                Name=it.Name,
                Description=it.Description
            }).ToList();
        }

        public List<RolePermissonDTO> GetRolePermisson(int RoleId)
        {
            //1、取出所有的功能权限
            //2、给角色已有的权限标记
            //3、组成结构树
            Int32 id = 1;//自增长序号,在easyui的treegrid中 将id设置成0会造成在获取子节点是出错
            SysRole selectedRole=_roleRepository.GetFilter(it => it.Id == RoleId, "FunctionRights").FirstOrDefault();
            List<SysFunctionRight> selectedRight=null;
            if (selectedRole != null)
            {
                selectedRight = selectedRole.FunctionRights;
            }
            else
            {
                return new List<RolePermissonDTO>();
            }
            List<SysModule> list = _moduleRepository.GetFilter(it => true,"ModuleOperates").ToList();
            List<RolePermissonDTO> rolePermissionList = new List<RolePermissonDTO>();
            list.ForEach(it => {
                RolePermissonDTO rpd = new RolePermissonDTO() { Id = id++, ModuleName = it.Name,IsModule=true,ParentId=it.ParentId,ModuleId=it.Id};
                if (it.ModuleOperates != null)
                {
                    foreach (var item in it.ModuleOperates)
                    {
                        if (rpd.children == null) rpd.children = new List<RolePermissonDTO>();
                        if (selectedRight != null&&selectedRight.Find(sr=>sr.KeyCode==item.KeyCode)!=null)
                        {
                            rpd.children.Add(new RolePermissonDTO() { Id = id++, ModuleName = "->", OperateName = item.Name, KeyCode = item.KeyCode, IsModule = false ,IsOwned=true,OperateId=item.Id});
                        }
                        else
                        {
                            rpd.children.Add(new RolePermissonDTO() { Id = id++, ModuleName = "->", OperateName = item.Name, KeyCode = item.KeyCode, IsModule = false ,OperateId=item.Id});
                        }
                    }
                };
                rolePermissionList.Add(rpd);
            });

            rolePermissionList.ForEach(it => {
                if (it.children == null) it.children = new List<RolePermissonDTO>();
                //rolePermissionList.FindAll(rpl => rpl.ParentId == it.Id && rpl.IsModule);
                it.children.AddRange(rolePermissionList.FindAll(rpl => rpl.ParentId == it.ModuleId && rpl.IsModule));
            });

            return rolePermissionList.Where(it => it.ParentId == null&&it.IsModule).ToList();
            //return rolePermissionList;
        }

        public bool Register(String name, String description)
        {
            if (_roleRepository.GetFilter(it => it.Name.Equals(name)).FirstOrDefault() != null)
            {
                throw new DomainException(Constant.ROLE_REPEATED);
            }
            else
            {
                SysRole role = new SysRole() { Name = name, Description = description };
                _roleRepository.Add(role);
                _unitOfWork.Commit();
                return true;
            }
        }

        public bool SaveRolePermission(Int32 roleId, List<String> keyCodes)
        {
            return true;
        }

        #endregion
    }
}