using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Simple.Services;

namespace Simple.Controllers
{
    public class SectionController : BaseController
    {
        //
        // GET: /Section/
        [Dependency]
        public ISectionService SectionService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadAllSections()
        {
            return Json(SectionService.GetAllSections(), JsonRequestBehavior.AllowGet);
        }

    }
}
