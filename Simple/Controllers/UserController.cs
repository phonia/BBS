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
            if (UserService.RegisterUser(new UserDTO()
            {
                Account = account,
                Password = password,
                Age = Convert.ToInt32(age),
                Sex = (Sex)Convert.ToInt32(sex),
                Tel = tel,
                Email = email,
                AccountType=AccountType.Register
            }))
            {
                Session["User"] = UserService.GetByAccount(account);
                return Json(new MessageDTO() { Success = true, Message = "注册成功" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new MessageDTO() { Success = false, Message = "未知原因注册失败" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUserByAccount(String account)
        {
            UserDTO user = UserService.GetByAccount(account);
            if (user == null)
            {
                return Json(new List<UserDTO>() { user }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new List<UserDTO>(), JsonRequestBehavior.AllowGet);
            }
        }
        

        //数据加载
        public JsonResult LoadSexCombobox()
        {
            List<ComboboxDTO> list = new List<ComboboxDTO>() { 
                new ComboboxDTO(){Id="0",Text="男"},
                new ComboboxDTO(){Id="1",Text="女"},
                new ComboboxDTO(){Id="2",Text="未知"}
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
