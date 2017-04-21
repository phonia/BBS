using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Services.Interface;

namespace BCP.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [Dependency]
        public ISysService SysService { get; set; }
        [Dependency]
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(String accountId,String accountPassword)
        {
            return null;
        }

    }
}
