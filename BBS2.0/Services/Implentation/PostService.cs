using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;
using BBS2._0.ViewModel;
using Infrastructure;

namespace BBS2._0.Services
{
    public class PostService:IPostService
    {
        private IPostRepository _postRepository = null;
        private IReplyRepository _replyRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public PostService(IUnitOfWork unitOfWork, IPostRepository postRepository, IReplyRepository replyRepository)
        {
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
            this._replyRepository = replyRepository;

            this._postRepository.UnitOfWork = unitOfWork;
            this._replyRepository.UnitOfWork = unitOfWork;
        }

        #region IPostService 成员

        public ViewModel.PostDTO IssuePost(int accountId, int sectionId, string title, string keyword, string content)
        {
            throw new NotImplementedException();
        }

        public ViewModel.PostDTO UpdatePost()
        {
            throw new NotImplementedException();
        }

        public bool UnInssuePost(int id)
        {
            throw new NotImplementedException();
        }

        public ViewModel.PostDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ViewModel.PostDTO> GetBySecionId(int sectionId)
        {
            return _postRepository.Select(it => it.Section.Id == sectionId, it => new PostDTO()
            {
                Id = it.Id,
                Keyword=it.Keyword,
                PublicTime=it.PublicTime,
                Title=it.Title,
                ScanAccount=it.ScanAccount
            })
            .ToList();
        }

        public ViewModel.PostDTO ReplyPost()
        {
            throw new NotImplementedException();
        }

        public ViewModel.PostDTO DeleteReply()
        {
            throw new NotImplementedException();
        }

        public ViewModel.PostDTO UpdateReply()
        {
            throw new NotImplementedException();
        }

        public PostDTO ScanPost(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}