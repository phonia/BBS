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
    public class PostController : BaseController
    {
        //
        // GET: /Post/
        [Dependency]
        public IPostService PostService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSectionPosts(Int32 sectionId)
        {
            List<PostDTO> list = PostService.GetBySecionId(sectionId);
            return Json(new DataGridDTO<PostDTO>() { rows = list, total = list.Count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostPost(Int32 sectionId)
        {
            return View();
        }

    }
}
