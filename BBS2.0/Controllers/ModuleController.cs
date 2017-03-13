using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS2._0.ViewModel;

namespace BBS2._0.Controllers
{
    public class ModuleController : BaseController
    {
        //
        // GET: /Module/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllModules()
        {
            DataGridDTO<ModuleDTO> dm = new DataGridDTO<ModuleDTO>()
            {
                rows = new List<ModuleDTO>() {
                    new ModuleDTO(){Id=1},
                    new ModuleDTO(){Id=2},
                    new ModuleDTO(){Id=3},
                    new ModuleDTO(){Id=4},
                    new ModuleDTO(){Id=5},
                    new ModuleDTO(){Id=6},
                    new ModuleDTO(){Id=7},
                    new ModuleDTO(){Id=8},
                    new ModuleDTO(){Id=9},
                    new ModuleDTO(){Id=10},
                    new ModuleDTO(){Id=11},
                    new ModuleDTO(){Id=12},
                    new ModuleDTO(){Id=13},
                    new ModuleDTO(){Id=14},
                    new ModuleDTO(){Id=15},
                    new ModuleDTO(){Id=16},
                    new ModuleDTO(){Id=17},
                    new ModuleDTO(){Id=18},
                    new ModuleDTO(){Id=19},
                    new ModuleDTO(){Id=20},
                    new ModuleDTO(){Id=21},
                    new ModuleDTO(){Id=22},
                    new ModuleDTO(){Id=23},
                    new ModuleDTO(){Id=24},
                    new ModuleDTO(){Id=25},
                    new ModuleDTO(){Id=26},
                    new ModuleDTO(){Id=27},
                    new ModuleDTO(){Id=28},
                    new ModuleDTO(){Id=29},
                },
                total=2
            };
            return Json(dm, JsonRequestBehavior.AllowGet);
        }
    }
}
