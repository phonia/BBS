using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Repository;
using Simple.Common;
using Simple.Models;
using Simple.Services;
using Simple.ViewModel;

namespace Simple.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Index/
        [Dependency]
        public IUserService UserService { get; set; }

        public ActionResult Index()
        {
            //UserService.RegisterUser(new UserDTO()
            //{
            //    Account = "Admin",
            //    Age = 28,
            //    Email = "642370175@qq.com",
            //    Password = "129921",
            //    Sex = Sex.Male,
            //    Tel = "15975455335"
            //});
            //using (var data = new DataContext())
            //{
            //    data.Users.Add(new User()
            //    {
            //        Account = "Admin",
            //        AcountType = AccountType.Manager,
            //        Age = 28,
            //        Email = "642370175@qq.com",
            //        Password = "129921",
            //        Sex = Sex.Male,
            //        Tel = "15975455335"
            //    });

            //    data.WebConfig.Add(new WebConfig());
            //    data.SaveChanges();
            //}

            //////////测试用代码 用于初始化数据库
            DataContext.InitDataBase();
            //if (Session["User"] != null)
            //{
            //    return View(Session["User"] as UserDTO);
            //}
            //else
            return View();
        }

    }
}
