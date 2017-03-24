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
    public class ModuleController : BaseController
    {
        [Dependency]
        public IModuleService ModuleService { get; set; }
        //
        // GET: /Module/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllModules(Int32 page,Int32 rows,String sort,String order)
        {
            List<ModuleDTO> list = ModuleService.GetAllModuels();

            DataGridDTO<ModuleDTO> dm = new DataGridDTO<ModuleDTO>()
            {
                rows = list.Skip((page - 1) * rows).Take(rows).ToList(),
                total=list.Count
            };
            return Json(dm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNotLeafModulsForCombobox()
        {
            List<ComboboxDTO> list = ModuleService.GetAllModuels().Where(it => it.IsLeaf == false)
                .Select(it => new ComboboxDTO() { Id = it.Id.ToString(), Text = it.Name }).ToList();
            list.Add(new ComboboxDTO() { Id = "-1", Text = "————无————" });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RegisterModule(String name, String moduleCode, String description, String isLeaf, String parent)
        {
            ModuleService.RegisterModule(name, moduleCode, description, isLeaf == null ? false : true, parent);
            return Json(new JsonMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateModuleBaseData(String id, String name, String url, String description, String isLeaf, String parent)
        {
            return Json(new JsonMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteModules(List<int> ids)
        {
            return Json(new JsonMessageDTO() { Success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModuleOperate(Int32 moduleId)
        {
            return View(moduleId);
        }

        public JsonResult GetModuleOperates(Int32 moduleId)
        {
            List<ModuleOperateDTO> list = ModuleService.GetModuleOperatesByModuleId(moduleId);
            return Json(new DataGridDTO<ModuleOperateDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RegisterModuleOperate(String name,String url,String isValid,String moduleId)
        {
            ModuleService.RegisterModuleOperate(name, url, isValid == null ? false : true, Convert.ToInt32(moduleId));
            return Json(new JsonMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult UpdateModuleOperates()
        {
            return Json(new JsonMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteModuleOperates()
        {
            return Json(new JsonMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
