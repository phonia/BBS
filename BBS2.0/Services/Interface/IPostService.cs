using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Cache;
using BBS2._0.Common;
using BBS2._0.Permission;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IPostService
    {
        [ControlPermission("PostManagement", ModuleOperateCode.Register)]
        [Cache(CacheMethod.RemoveCollection,"Post")]
        PostDTO IssuePost(Int32 accountId, Int32 sectionId, String title, String keyword, String content);

        [ControlPermission("PostManagement", ModuleOperateCode.Update)]
        [Cache(CacheMethod.RemoveCollection, "Post")]
        PostDTO UpdatePost();//参数不明 暂不使用

        [ControlPermission("PostManagement", ModuleOperateCode.Del)]
        [Cache(CacheMethod.RemoveCollection, "Post")]
        bool UnInssuePost(Int32 id);

        [ControlPermission("PostManagement", ModuleOperateCode.Detail)]
        PostDTO ScanPost(Int32 id);

        [ControlPermission("PostManagement", ModuleOperateCode.Detail)]
        [Cache(CacheMethod.GetCollection, "Post")]
        PostDTO GetById(Int32 id);

        [ControlPermission("SectionManagement", ModuleOperateCode.Detail)]
        [Cache(CacheMethod.GetCollection, "Post")]
        List<PostDTO> GetBySecionId(Int32 sectionId);

        //是不是需要将对回复的处理放到帖子的服务方法里呢？因为帖子与回复的关系相当的紧密
        [ControlPermission("ReplyManagement", ModuleOperateCode.Add)]
        [Cache(CacheMethod.GetCollection, "Post")]
        void ReplyPost(Int32 accountId, Int32 postId, String content);

        [ControlPermission("ReplyManagement", ModuleOperateCode.Del)]
        PostDTO DeleteReply();
        PostDTO UpdateReply();

        [ControlPermission("PostManagement", ModuleOperateCode.Detail)]
        [Cache(CacheMethod.GetCollection, "Post")]
        List<ReplyDTO> GetPostReplies(Int32 postId);
    }
}