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
            List<ComboboxDTO> list = EnumHepler.ConvertEnumToComboboxDTO<MenuTypeDTO>();
            list.Insert(0, new ComboboxDTO() { Id = "-1", Text = "———请选择———" });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadMenuParentCombobox()
        {
            var list = ModuleMenuService.GetAllMenu().Select(it => new ComboboxDTO() { Id = it.Id.ToString(), Text = it.MenuName }).ToList();
            list.Insert(0, new ComboboxDTO() { Id = "-1", Text = "———请选择———" });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddMenu(String menuName,String menuCode,int menuType,int parentId,String url,bool isPage,bool isEnable,bool isVisible)
        {
            if (ModuleMenuService.AddMenu(menuName, menuCode, menuType, parentId, url, isPage, isEnable, isVisible))
            {
                return Json(new JSONMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JSONMessageDTO() { Success = false,Message="Not Mentioned" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
