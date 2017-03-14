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

        public JsonResult GetAllModules()
        {
            List<ModuleDTO> list = ModuleService.GetAllModuels();

            DataGridDTO<ModuleDTO> dm = new DataGridDTO<ModuleDTO>()
            {
                rows = list,
                total=list.Count
            };
            return Json(dm, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNotLeafModulsForCombobox()
        {
            //List<ComboboxDTO> list = ModuleService.GetAllModuels().Where(it=>it.IsLeaf==false)
            //    .Select(it=>new ComboboxDTO(){Id=it.Id.ToString(),Text=it.Name}).ToList();
            //list.Add(new ComboboxDTO(){Id="0",Text="没有数据"});
            List<ComboboxDTO> list = new List<ComboboxDTO>() { 
                new ComboboxDTO(){Id="0",Text="男"},
                new ComboboxDTO(){Id="1",Text="女"},
                new ComboboxDTO(){Id="2",Text="未知"}
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RegisterModule()
        {
            return Json(new JsonMessageDTO() { Success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteModule()
        {
            return Json(new JsonMessageDTO() { Success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
