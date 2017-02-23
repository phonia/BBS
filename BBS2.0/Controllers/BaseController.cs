using System;
using System.Collections.Generic;
using System.Linq;
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
            if (excepton is DomainException)
            {
                ModelState.AddModelError("DomainError", excepton.Message);
                filterContext.ExceptionHandled = true;
                ActionInvoker.InvokeAction(filterContext.Controller.ControllerContext, "DomainError");
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
            //return Content(
            //    _json.Serialize(
            //    new { 
            //        Success=false,
            //        Message=sb.ToString()
            //    }
            //    )
            //    , "text/html;charset=UTF-8");
        }

    }
}
