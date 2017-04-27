using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Microsoft.Practices.Unity;
using Services.Interface;
using ViewModel;

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

        [Dependency]
        public IModuleMenuService ModuleMenuService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            SysService.InitDataBase();
            return View();
        }

        [HttpPost]
        public JsonResult Login(String name,String password)
        {
            UserDTO user=UserService.Login(name, password);
            if (user!=null)
            {
                Session[Constant.LoginUser] = user;
                return Json(new JSONMessageDTO() { Success = true, Message =Constant.SUCCESS_MESSAGE }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JSONMessageDTO() { Success = false, Message =Constant.FAILED_MESSAGE }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetTopMenu()
        {
            var list = ModuleMenuService.GetTopMenu();
            return Json(new JSONMessageDTO() { Success = true, Message = Constant.SUCCESS_MESSAGE, Data = list }, JsonRequestBehavior.AllowGet);
        }

    }
}
