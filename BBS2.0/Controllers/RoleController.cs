using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS2._0.Services;
using BBS2._0.ViewModel;
using Microsoft.Practices.Unity;

namespace BBS2._0.Controllers
{
    public class RoleController : BaseController
    {
        //
        // GET: /Role/
        [Dependency]
        public IRoleService RoleService { get; set; }

        [Dependency]
        public IModuleService ModuleService { get; set; }

        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult LoadRoles()
        {
            //List<RoleDTO> list = new List<RoleDTO>() { 
            //    new RoleDTO(){Id=1,Name="测试",Description=""}
            //};
            List<RoleDTO> list = RoleService.GetAllRoles();
            return Json(new DataGridDTO<RoleDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadRolePermisson(Int32 roleId)
        {
            List<RolePermissonDTO> list = RoleService.GetRolePermisson(roleId);
            return Json(new DataGridDTO<RolePermissonDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Register(String name, String description)
        {
            if (RoleService.Register(name, description))
            {
                return Json(new JsonMessageDTO() { Success = true, Message = "success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonMessageDTO() { Success = false, Message = "Not Mentioned!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SaveRolePermisson(String keycodes,Int32 roleId)
        {
            if (String.IsNullOrWhiteSpace(keycodes))
            {
                return Json(new JsonMessageDTO() { Success = false, Message = "参数不能为空" },JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<String> keyCode = keycodes.Split(',').ToList();
                if (RoleService.SaveRolePermission(roleId, keyCode))
                {
                    return Json(new JsonMessageDTO() { Success = true, Message = "success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new JsonMessageDTO() { Success = false, Message = "Not Mentioned!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult LoadModuleTree()
        {
            List<ModuleDTO> list = ModuleService.GetAllModuels();//.Select(it => new TreeDTO() { id = 1, text = "权限管理", state = "closed", iconCls = "", attributes = new TreeAttributeDTO() { } }).ToList();

            return Json(GenerateTree(list), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRole(Int32 roleId)
        {
            if (RoleService.DeleteRole(roleId))
            {
                return Json(new JsonMessageDTO() { Success = true, Message = "success" },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonMessageDTO() { Success = false, Message = "Not Mentioned!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public List<TreeDTO> GenerateTree(List<ModuleDTO> list)
        {
            //new TreeDTO(){id=11,text="模块设置",state="opend",iconCls="icon-nav",attributes=new TreeAttributeDTO(){url="/Module"}},
            List<TreeDTO> tree = new List<TreeDTO>();
            int i = list.Count-1;
            while (list.Count > 0)
            {
                if (i < 0) i = list.Count-1;
                if (list[i].ParentId < 0)
                {
                    var item = list[i];
                    list.Remove(item);
                    tree.Add(new TreeDTO() { id = item.Id, text = item.Name, state = "open", iconCls = "", attributes = new TreeAttributeDTO() });
                }
                else
                {
                    if (list.Where(it => it.Id == list[i].ParentId).FirstOrDefault() != null)
                    { }
                    else
                    {
                        AddTreeNode(tree,list[i]);
                        list.Remove(list[i]);
                    }
                }
                i--;
            }
            return tree;
        }

        //算法有问题
        void AddTreeNode(List<TreeDTO> tree, ModuleDTO node)
        {
            foreach (var item in tree)
            {
                if (item.id == node.ParentId)
                {
                    if (item.children == null)
                    {
                        item.children = new List<TreeDTO>();
                        item.state = "closed";
                        item.iconCls = "";
                    }
                    item.children.Add(new TreeDTO() { id = node.Id, text = node.Name, state = "open", iconCls = "", attributes = new TreeAttributeDTO() });
                    break;
                }
                else if (item.children != null)
                {
                    AddTreeNode(item.children, node);
                }
            }
        }

    }
}
