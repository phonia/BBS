using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCP.WebUI.Helper;
using Microsoft.Practices.Unity;
using Services.Interface;
using ViewModel;

namespace BCP.WebUI.Controllers
{
    public class MenuController : BaseController
    {
        //
        // GET: /Menu/
        [Dependency]
        public IModuleMenuService ModuleMenuService { get; set; }

        public ActionResult EditMenu()
        {
            return View();
        }

        public JsonResult GetAllMenus()
        {
            var list = ModuleMenuService.GetAllMenu();
            return Json(new DataGridDTO<ModuleMenuDTO>() { rows = list, total = list.Count }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadMenuTypeCombobxo()
        {
            return Json(EnumHepler.ConvertEnumToComboboxDTO<MenuTypeDTO>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadMenuParentCombobox()
        {
            var list = ModuleMenuService.GetAllMenu();
            return Json(list.Select(it => new ComboboxDTO() { Id = it.Id.ToString(), Text = it.MenuName }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
