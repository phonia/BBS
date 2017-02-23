using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Simple.Services;
using Simple.ViewModel;

namespace Simple.Controllers
{
    public class SectionController : BaseController
    {
        //
        // GET: /Section/
        [Dependency]
        public ISectionService SectionService { get; set; }

        public ActionResult Index(String sectionId)
        {
            SectionDTO section = SectionService.GetById(Convert.ToInt32(sectionId));
            return View(section);
        }

        public JsonResult LoadAllSections()
        {
            List<SectionDTO> list=SectionService.GetAllSections();
            return Json(new DataGridDTO<SectionDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }

    }
}
