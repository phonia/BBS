using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;
using Simple.Models;
using Simple.ViewModel;

namespace Simple.Services
{

    /**
     * 1、没有做参数验证
     * 2、没有做异常处理
     * 3、没有做缓存处理
     * 4、没有做日志处理
     * **/
    public class SectionService:ISectionService
    {

        private ISectionRepository _sectionRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public SectionService(IUnitOfWork unitOfWork, ISectionRepository sectionRepository)
        {
            this._unitOfWork = unitOfWork;
            this._sectionRepository = sectionRepository;

            this._sectionRepository.UnitOfWork = unitOfWork;
        }

        #region ISectionService 成员

        public List<SectionDTO> GetAllSections()
        {
            return this._sectionRepository.Select<SectionDTO>(it => true, it => new SectionDTO()
            {
                Id = it.Id,
                Title = it.Title,
                Description = it.Description,
                KeyWord = it.KeyWord,
                PostsAccount = it.Posts.Count
            }).ToList();
        }

        public SectionDTO GetById(int id)
        {
            return this._sectionRepository.Select<SectionDTO>(it => it.Id == id, it => new SectionDTO()
            {
                Id = it.Id,
                Title = it.Title,
                Description = it.Description,
                KeyWord = it.KeyWord,
                PostsAccount = it.Posts.Count
            }).First();
        }

        #endregion
    }
}