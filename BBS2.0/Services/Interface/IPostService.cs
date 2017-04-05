using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using BBS2._0.Permission;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IPostService
    {
        [ControlPermission("PostManagement", ModuleOperateCode.Register.ToString())]
        PostDTO IssuePost(Int32 accountId, Int32 sectionId, String title, String keyword, String content);

        [ControlPermission("PostManagement", ModuleOperateCode.Update.ToString())]
        PostDTO UpdatePost();//参数不明 暂不使用

        [ControlPermission("PostManagement", ModuleOperateCode.Del.ToString())]
        bool UnInssuePost(Int32 id);

        [ControlPermission("PostManagement", ModuleOperateCode.Detail.ToString())]
        PostDTO ScanPost(Int32 id);

        [ControlPermission("PostManagement", ModuleOperateCode.Detail.ToString())]
        PostDTO GetById(Int32 id);

        [ControlPermission("SectionManagement", ModuleOperateCode.Detail.ToString())]
        List<PostDTO> GetBySecionId(Int32 sectionId);

        //是不是需要将对回复的处理放到帖子的服务方法里呢？因为帖子与回复的关系相当的紧密
        [ControlPermission("ReplyManagement", ModuleOperateCode.Add.ToString())]
        void ReplyPost(Int32 accountId, Int32 postId, String content);

        [ControlPermission("ReplyManagement", ModuleOperateCode.Del.ToString())]
        PostDTO DeleteReply();
        PostDTO UpdateReply();

        [ControlPermission("PostManagement", ModuleOperateCode.Detail.ToString())]
        List<ReplyDTO> GetPostReplies(Int32 postId);
    }
}