using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using BBS2._0.Models;
using BBS2._0.ViewModel;
using Infrastructure;

namespace BBS2._0.Services
{
    public class PostService:IPostService
    {
        private IPostRepository _postRepository = null;
        private IReplyRepository _replyRepository = null;
        private IAccountRepository _accountRepository = null;
        private ISectionRepository _sectionRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public PostService(IUnitOfWork unitOfWork, IPostRepository postRepository, IReplyRepository replyRepository,
            IAccountRepository accountRepository,ISectionRepository seciontRepository)
        {
            this._unitOfWork = unitOfWork;
            this._postRepository = postRepository;
            this._replyRepository = replyRepository;
            this._accountRepository = accountRepository;
            this._sectionRepository = seciontRepository;

            this._postRepository.UnitOfWork = unitOfWork;
            this._replyRepository.UnitOfWork = unitOfWork;
            this._accountRepository.UnitOfWork = unitOfWork;
            this._sectionRepository.UnitOfWork = unitOfWork;
        }

        #region IPostService 成员

        public ViewModel.PostDTO IssuePost(int accountId, int sectionId, string title, string keyword, string content)
        {
            //account<=0 匿名用户
            Account poster = null;
            if (accountId <= 0)
            {
                poster = _accountRepository.GetFilter(it => it.Name.Equals(Constant.ACCOUNT_NAME_ANONYMOUS_EN)).FirstOrDefault();
            }
            else
            {
                poster = _accountRepository.GetByKey(accountId);
            }
            if (poster == null) throw new DomainException(Constant.ACCOUNT_NOTFOUND);

            Section section = _sectionRepository.GetByKey(sectionId);
            if (section == null) throw new DomainException(Constant.SECTION_NOTFOUND);

            Reply reply = new Reply()
            {
                Content = content,
                Level=0,
                Replyer=poster,
                ReplyTime=DateTime.Now
            };

            Post post = new Post()
            {
                Keyword = keyword,
                Poster = poster,
                PublicTime = DateTime.Now,
                Replies = new List<Reply>(){reply},
                ScanAccount=0,
                Section=section,
                Title=title
            };

            _postRepository.Add(post);
            _unitOfWork.Commit();

            PostDTO postDTO = _postRepository.Select(it => true, it => new PostDTO()
            {
                Id = it.Id,
                Keyword = it.Keyword,
                PublicTime = it.PublicTime,
                ScanAccount = it.ScanAccount,
                Title = it.Title,
                Poster = new AccountDTO()
                {
                    Id = it.Poster.Id,
                    Age = it.Poster.Age,
                    Email = it.Poster.Email,
                    Name = it.Poster.Name,
                    Password = it.Poster.Password,
                    Sex = it.Poster.Sex,
                    Tel = it.Poster.Tel
                },
                //不需要返回此属性的值
                //LastReply = it.Replies.OrderByDescending(e => e.Id).FirstOrDefault() == null ? null : new ReplyDTO()
                //{
                //    Id = it.Replies.OrderByDescending(e => e.Id).FirstOrDefault().Id,
                //    Content = it.Replies.OrderByDescending(e => e.Id).FirstOrDefault().Content,
                //    Level = it.Replies.OrderByDescending(e => e.Id).FirstOrDefault().Level,
                //    ReplyTime = it.Replies.OrderByDescending(e => e.Id).FirstOrDefault().ReplyTime
                //}
                ReplyAccount=it.Replies.Count
            },
            it => it.RowVersion, false)
            .FirstOrDefault();
            if (postDTO == null) throw new DomainException("未知错误");
            return postDTO;
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

        public List<ReplyDTO> GetPostReplies(Int32 postId)
        {
            return _replyRepository.Select(it => it.Post.Id == postId, it => new ReplyDTO()
            {
                Id = it.Id,
                Content = it.Content,
                Level = it.Level,
                ReplyTime = it.ReplyTime,
                Replyer = new AccountDTO()
                {
                    Age = it.Replyer.Age,
                    Email=it.Replyer.Email,
                    Id=it.Replyer.Id,
                    Sex=it.Replyer.Sex,
                    Name=it.Replyer.Name,
                    Password=it.Replyer.Password,
                    Tel=it.Replyer.Tel
                }
            })
            .ToList();
        }

        #endregion
    }
}