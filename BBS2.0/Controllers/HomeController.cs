using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS2._0.Repository;
using BBS2._0.Services;
using BBS2._0.ViewModel;
using Microsoft.Practices.Unity;

namespace BBS2._0.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            DataContext.InitDataBase();
            return View();
        }

        public ActionResult Portal()
        {
            //throw new DomainException("");
            return View();
        }

        public ActionResult Management()
        {
            return View();
        }

        public JsonResult GetGMMenu()
        {
            //new TreeDTO(){id=1,text="",state="",iconCls="",attributes=new TreeAttributeDTO(){},children=new List<TreeDTO>(){}}
            List<TreeDTO> td = new List<TreeDTO>() { 
                new TreeDTO(){id=1,text="权限管理",state="closed",iconCls="",attributes=new TreeAttributeDTO(){},children=new List<TreeDTO>(){
                    new TreeDTO(){id=11,text="模块设置",state="opend",iconCls="icon-nav",attributes=new TreeAttributeDTO(){url="/Module"}},
                    new TreeDTO(){id=12,text="角色设置",state="opend",iconCls="icon-nav",attributes=new TreeAttributeDTO(){url="/Role"}},
                    new TreeDTO(){id=12,text="用户设置",state="opend",iconCls="icon-nav",attributes=new TreeAttributeDTO(){url="/Account"}}
                }}
            };
            return Json(td, JsonRequestBehavior.AllowGet);
        }

    }
}
