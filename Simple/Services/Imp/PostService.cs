using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using Simple.Models;
using Simple.ViewModel;
using Simple.Common;

namespace Simple.Services
{
    public class PostService:IPostService
    {
        private IUserRepository _userRepository = null;
        private ISectionRepository _sectionRepository = null;
        private IPostRepository _postRepository = null;
        private IUnitOfWork _unitOfWork = null;

        private PostService(IUnitOfWork unitOfWork, IPostRepository postRepository,
            ISectionRepository sectionRepository,IUserRepository userRepository)
        {
            this._sectionRepository = sectionRepository;
            this._postRepository = postRepository;
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;

            this._postRepository.UnitOfWork = unitOfWork;
            this._sectionRepository.UnitOfWork = unitOfWork;
            this._postRepository.UnitOfWork = unitOfWork;
        }

        #region IPostService 成员

        public List<PostDTO> GetPostBySectionId(int postId)
        {
            return _postRepository.GetFilter(it => it.Section.Id.Equals(postId))
                .MapperTo<Post, PostDTO>()
                .ToList();
        }

        public bool IssuePost(int userId, int sectionId, PostDTO postDTO)
        {
            Post post = postDTO.MapperTo<PostDTO, Post>();
            post.Poster = _userRepository.GetByKey(userId);
            post.Section = _sectionRepository.GetByKey(sectionId);
            post.CastTime = DateTime.Now;
            _postRepository.Add(post);
            _unitOfWork.Commit();
            return true;
        }

        public PostDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}