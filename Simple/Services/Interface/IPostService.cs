using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.ViewModel;

namespace Simple.Services
{
    interface IPostService
    {
        List<PostDTO> GetPostBySectionId(Int32 postId);
        bool IssuePost(Int32 userId, Int32 sectionId, PostDTO postDTO);
        PostDTO GetById(Int32 id);
    }
}
