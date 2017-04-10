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
            if (accountId <= 0)
            {
                //poster = _accountRepository.GetFilter(it => it.Name.Equals(Constant.ACCOUNT_NAME_ANONYMOUS_EN)).FirstOrDefault();
                accountId= _accountRepository.GetFilter(it => it.Name.Equals(Constant.ACCOUNT_NAME_ANONYMOUS_EN)).First().Id; 
            }

            Reply reply = new Reply()
            {
                Content = content,
                Level=0,
                ReplyerId=accountId,
                ReplyTime=DateTime.Now
            };

            Post post = new Post()
            {
                Keyword = keyword,
                PosterId=accountId,
                PublicTime = DateTime.Now,
                Replies = new List<Reply>(){reply},
                ScanAccount=0,
                SectionId=sectionId,
                Title=title
            };

            _postRepository.Add(post);
            _unitOfWork.Commit();

            PostDTO postDTO = _postRepository.Select(it => it.PosterId==accountId, it => new PostDTO()
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
                    Tel = it.Poster.Tel,
                    RoleId=it.Poster.Role.Id,//需要测试是否可用
                    RoleName=it.Poster.Role.Name
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
            if (postDTO == null)
            {
                //throw new DomainException("未知错误");
                throw new DomainBusinessException("");
            }
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

        public PostDTO GetById(Int32 id)
        {
            PostDTO post = _postRepository.Select(it => it.Id == id, it => new PostDTO()
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
                    Tel = it.Poster.Tel,
                    RoleId=it.Poster.Role.Id,//需要测试是否可用
                    RoleName=it.Poster.Role.Name
                },
                ReplyAccount=it.Replies.Count
            }).FirstOrDefault();
            if (post == null)
            {
                //throw new DomainException("");
                throw new DomainDataException("");
            }
            return post;
        }

        public List<ViewModel.PostDTO> GetBySecionId(int sectionId)
        {
            var ret = _postRepository.Select(it => it.Section.Id == sectionId, it => new PostDTO()
            {
                Id = it.Id,
                Keyword = it.Keyword,
                PublicTime = it.PublicTime,
                Title = it.Title,
                ScanAccount = it.ScanAccount
            });
            return ret.ToList();
        }

        public void ReplyPost(Int32 accountId,Int32 postId,String content)
        {
            //var post = _postRepository.GetFilter(it => it.Id == postId, "Replies").FirstOrDefault();
            //if (post == null) throw new DomainException("");

            //Account replyer = null;
            //if (accountId <= 0)
            //{
            //    replyer = _accountRepository.GetFilter(it => it.Name.Equals(Constant.ACCOUNT_NAME_ANONYMOUS_EN)).FirstOrDefault();
            //}
            //else
            //{
            //    replyer = _accountRepository.GetByKey(accountId);
            //}
            //if (replyer == null) throw new DomainException(Constant.ACCOUNT_NOTFOUND);
            if (accountId <= 0)
            {
                accountId = _accountRepository.GetFilter(it => it.Name.Equals(Constant.ACCOUNT_NAME_ANONYMOUS_EN)).First().Id;
            }

            Int32 count = _postRepository.Select(it => it.Id == postId, it => it.Replies.Count).First();

            Reply reply = new Reply()
            {
                Content = content,
                Level=count+1,
                PostId=postId,
                ReplyerId=accountId,
                ReplyTime=DateTime.Now
            };
            _replyRepository.Add(reply);
            _unitOfWork.Commit();
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
            //浏览帖子
            Post post = _postRepository.GetByKey(id);
            post.ScanAccount += 1;
            _unitOfWork.Commit();
            return _postRepository.Select(it => it.Id==id, it => new PostDTO()
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
                    Tel = it.Poster.Tel,
                    RoleId = it.Poster.Role.Id,//需要测试是否可用
                    RoleName = it.Poster.Role.Name
                },
                ReplyAccount = it.Replies.Count
            })
            .First();
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
                    Tel=it.Replyer.Tel,
                    RoleId = it.Replyer.Role.Id,//需要测试是否可用
                    RoleName = it.Replyer.Role.Name
                }
            })
            .ToList();
        }

        #endregion
    }
}