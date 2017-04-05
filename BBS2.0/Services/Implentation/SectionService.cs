using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;
using BBS2._0.Permission;
using BBS2._0.ViewModel;
using Infrastructure;

namespace BBS2._0.Services
{
    public class SectionService:ISectionService
    {
        private ISectionRepository _sectionRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public SectionService(IUnitOfWork unitOfWork, ISectionRepository SectionRepository)
        {
            this._sectionRepository = SectionRepository;
            this._unitOfWork = unitOfWork;

            this._sectionRepository.UnitOfWork = unitOfWork;
        }

        #region ISectionService 成员

        public bool RegisterSecion(string title, string description)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSection(int id, string title, string description)
        {
            throw new NotImplementedException();
        }

        public bool UnRegisterSection(int id)
        {
            throw new NotImplementedException();
        }

        public ViewModel.SectionDTO GetById(int id)
        {
            var ret = _sectionRepository.Select(it => it.Id == id, it => new SectionDTO()
            {
                Id = it.Id,
                Title = it.Title,
                PostsAccount = it.Posts.Count,
                LastPost = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault() == null ? null :
                new PostDTO()
                {
                    Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Id,
                    Keyword = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Keyword,
                    PublicTime = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().PublicTime,
                    Title = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Title,
                    ScanAccount = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().ScanAccount,
                    ReplyAccount = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.Count,
                    Poster = new AccountDTO()
                    {
                        Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Id,
                        Age = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Age,
                        Email = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Email,
                        Name = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Name,
                        Sex = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Sex,
                        Password = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Password,
                        Tel = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Tel,
                        RoleId=it.Posts.OrderByDescending(e=>e.Id).FirstOrDefault().Poster.Role.Id,//需要测试
                        RoleName=it.Posts.OrderByDescending(e=>e.Id).FirstOrDefault().Poster.Role.Name
                    },
                    LastReply = (it.Posts.OrderByDescending(e => e.Id).FirstOrDefault() == null || it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault() == null) ? null :
                    new ReplyDTO()
                    {
                        Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Id,
                        Content = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Content,
                        Level = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Level,
                        ReplyTime = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().ReplyTime
                        //Replyer = new AccountDTO()//无法获取数据
                        //{
                        //    Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Id,
                        //    Age=it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Age,
                        //    Email = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Email,
                        //    Name = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Name,
                        //    Password = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Password,
                        //    Sex = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Sex,
                        //    Tel = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Tel
                        //}
                    }
                },
                ReplyAccount = it.Posts.Count <= 0 ? 0 :
                (it.Posts.Select(e => e.Replies.Count)).Sum()
            });
            return ret.ToList().FirstOrDefault();
        }

        public List<ViewModel.SectionDTO> GetAll()
        {
            var ret = _sectionRepository.Select(it => true, it => new SectionDTO()
            {
                Id = it.Id,
                Title = it.Title,
                PostsAccount = it.Posts.Count,
                LastPost = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault() == null ? null :
                new PostDTO()
                {
                    Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Id,
                    Keyword = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Keyword,
                    PublicTime = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().PublicTime,
                    Title = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Title,
                    ScanAccount = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().ScanAccount,
                    ReplyAccount = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.Count,
                    Poster = new AccountDTO()
                    {
                        Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Id,
                        Age = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Age,
                        Email = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Email,
                        Name = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Name,
                        Sex = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Sex,
                        Password = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Password,
                        Tel = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Poster.Tel,
                        RoleId=it.Posts.OrderByDescending(e=>e.Id).FirstOrDefault().Poster.Role.Id,
                        RoleName=it.Posts.OrderByDescending(e=>e.Id).FirstOrDefault().Poster.Role.Name
                    },
                    LastReply = (it.Posts.OrderByDescending(e => e.Id).FirstOrDefault() == null || it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault() == null) ? null :
                    new ReplyDTO()
                    {
                        Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Id,
                        Content = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Content,
                        Level = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Level,
                        ReplyTime = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().ReplyTime
                        //Replyer = new AccountDTO()//无法获取数据 
                        //{
                        //    Id = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Id,
                        //    Age = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Age,
                        //    Email = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Email,
                        //    Name = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Name,
                        //    Password = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Password,
                        //    Sex = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Sex,
                        //    Tel = it.Posts.OrderByDescending(e => e.Id).FirstOrDefault().Replies.OrderByDescending(e => e.Id).FirstOrDefault().Replyer.Tel
                        //}
                    }
                },
                ReplyAccount = it.Posts.Count <= 0 ? 0 :
                (it.Posts.Select(e => e.Replies.Count)).Sum()
            });
            return ret.ToList();
        }

        #endregion
    }
}