using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BBS2._0.ViewModel;

namespace BBS2._0.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected override void OnException(ExceptionContext filterContext)
        {
            var excepton = filterContext.Exception;
            if (this.GetType().GetMethod(RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString()).ReturnType==typeof(JsonResult))
            {
                ModelState.AddModelError("DomainError", excepton.Message);
                filterContext.ExceptionHandled = true;
                ActionInvoker.InvokeAction(filterContext.Controller.ControllerContext, "DomainError");
            }

            if (this.GetType().GetMethod(RouteData.Route.GetRouteData(this.HttpContext).Values["action"].ToString()).ReturnType != typeof(JsonResult))
            {
                // 标记异常已处理
                filterContext.ExceptionHandled = true;
                // 跳转到错误页
                filterContext.Result = new RedirectResult(Url.Action("Error", "Shared"));
                filterContext.HttpContext.Response.Redirect("/Shared/Error");
            }
        }



        public JsonResult DomainError()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            ModelState.Keys.Where(it => ModelState[it].Errors.Count > 0).ToList()
                .ForEach(it => ModelState[it].Errors.ToList().ForEach(node =>
                    sb.Append(node.ErrorMessage + " ")));
            return Json(new JsonMessageDTO
            {
                Success = false,
                Message = sb.ToString(),
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
