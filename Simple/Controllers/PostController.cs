using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple.Controllers
{
    public class PostController : BaseController
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }

    }
}
