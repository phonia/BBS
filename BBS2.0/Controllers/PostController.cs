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
        [Dependency]
        public IAccountService AccountService { get; set; }

        public ActionResult Index(Int32 postId)
        {
            return View(PostService.GetById(postId));
        }

        public JsonResult GetSectionPosts(Int32 sectionId)
        {
            List<PostDTO> list = PostService.GetBySecionId(sectionId);
            return Json(new DataGridDTO<PostDTO>() { rows = list, total = list.Count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostPost(Int32 sectionId)
        {
            return View(sectionId);
        }

        [HttpPost]
        public JsonResult PostPost(Int32 sectionId,String title, String content)
        {
            Int32 accountId = Session["AccountDTO"] != null
                ? (Session["AccountDTO"] as AccountDTO).Id
                : -1;
            PostDTO postDTO = PostService.IssuePost(accountId, sectionId, title, "", content);
            return Json(new JsonMessageDTO() { Success = true, Data = postDTO }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPostReplies(Int32 postId)
        {
            //此处是否算是浏览帖子？
            PostService.ScanPost(postId);
            List<ReplyDTO> list = PostService.GetPostReplies(postId);
            return Json(new DataGridDTO<ReplyDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReplyPost(Int32 postId)
        {
            return View(postId);
        }

        [HttpPost]
        public JsonResult ReplyPost(Int32 postId, String content)
        {
            Int32 accountId = Session["AccountDTO"] != null
                ? (Session["AccountDTO"] as AccountDTO).Id
                : -1;
            PostService.ReplyPost(accountId, postId, content);
            PostDTO post=PostService.GetById(postId);
            return Json(new JsonMessageDTO() { Success = true, Data = post }, JsonRequestBehavior.AllowGet);
        }
    }
}
