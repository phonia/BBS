using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Simple.Common;
using Simple.Services;
using Simple.ViewModel;

namespace Simple.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/
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
        public JsonResult Login(String account,String password)
        {
            if (UserService.Login(account, password))
            {
                UserDTO user=UserService.GetByAccount(account);
                Session["User"] = user;
                return Json(new MessageDTO() { Success = true, Message = "Success" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new MessageDTO() { Success = false, Message = "未知原因登录失败" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(String account,String password,String sex,String age,String tel,String email)
        {
            return Json(new MessageDTO() { Success = true, Message = "前端方法测试" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserByAccount(String account)
        {
            return Json(new UserDTO() { Account = "baichuan", AccountType = AccountType.Register, Age = 28, Email = "baichuan@hot.com", Id = 1, Password = "129921", Sex = Sex.Male, Tel = "15975455335" }, JsonRequestBehavior.AllowGet);
        }
        

        //数据加载
        public JsonResult LoadSexCombobox()
        {
            List<ComboboxDTO> list = new List<ComboboxDTO>() { 
                new ComboboxDTO(){Id="1",Text="男"},
                new ComboboxDTO(){Id="2",Text="女"},
                new ComboboxDTO(){Id="3",Text="未知"}
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadLoginUser()
        {
            if (Session["User"] == null)
                return Json(new List<UserDTO>(), JsonRequestBehavior.AllowGet);
            else
            {
                return Json(new List<UserDTO>() { Session["User"] as UserDTO }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
