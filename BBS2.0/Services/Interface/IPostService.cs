using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IPostService
    {
        PostDTO IssuePost(Int32 accountId, Int32 sectionId, String title, String keyword, String content);
        PostDTO UpdatePost();//参数不明 暂不使用
        bool UnInssuePost(Int32 id);
        PostDTO ScanPost(Int32 id);

        PostDTO GetById(Int32 id);
        List<PostDTO> GetBySecionId(Int32 sectionId);

        //是不是需要将对回复的处理放到帖子的服务方法里呢？因为帖子与回复的关系相当的紧密
        void ReplyPost(Int32 accountId, Int32 postId, String content);
        PostDTO DeleteReply();
        PostDTO UpdateReply();

        List<ReplyDTO> GetPostReplies(Int32 postId);
    }
}