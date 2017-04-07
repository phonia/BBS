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
    public class SectionController : BaseController
    {
        //
        // GET: /Section/
        [Dependency]
        public ISectionService SectionService { get; set; }

        public ActionResult Index(Int32 sectionId)
        {
            SectionDTO sectionDTO = SectionService.GetById(sectionId);
            return View(sectionDTO);
        }

        public JsonResult LoadAllSections()
        {
            //throw new DomainException("");
            List<SectionDTO> list=SectionService.GetAll();
            return Json(new DataGridDTO<SectionDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }
    }
}
