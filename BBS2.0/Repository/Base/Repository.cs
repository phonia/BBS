﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using Infrastructure;

namespace BBS2._0.Repository
{
    public abstract class EFRepository<TEntity, Tld> : IRepository<TEntity, Tld> where TEntity : EntityBase, IAggregateRoot
    {
        protected IEFUnitOfWork _unitOfWork = null;

        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            if (entity.GetBrokens().Count()>0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("The Entity for Saving has some broken-rules:");
                foreach (var rule in entity.GetBrokens())
                {
                    sb.Append(rule.Property + "<>" + rule.Rule+" ");
                }
                //throw new DomainException(sb.ToString());
                throw new DomainBusinessException(sb.ToString());
            }
            EntityState state = _unitOfWork.DbContext.Entry<TEntity>(entity).State;
            if (state == EntityState.Detached)
                _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Added;
        }

        public virtual void RemoveNonCascaded(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            EntityState state = _unitOfWork.DbContext.Entry<TEntity>(entity).State;
            if (state == EntityState.Detached)
                _unitOfWork.DbContext.Set<TEntity>().Attach(entity);
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public virtual void RemoveNonCascaded(Tld t)
        {
            TEntity entity = _unitOfWork.DbContext.Set<TEntity>().Find(t);
            if (entity == null) throw new ArgumentNullException();
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public virtual void RemoveCascaded(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveCascaded(Tld t)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException();
            if (entity.GetBrokens().Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.Append("The Entity for Saving has some broken-rules:");
                foreach (var rule in entity.GetBrokens())
                {
                    sb.Append(rule.Property + "<>" + rule.Rule+" ");
                }
                //throw new DomainException(sb.ToString());
                throw new DomainBusinessException(sb.ToString());
            }
            _unitOfWork.DbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return (IUnitOfWork)_unitOfWork;
            }
            set
            {
                if (value is IEFUnitOfWork)
                    this._unitOfWork = (IEFUnitOfWork)value;
                else
                    throw new ArgumentException();
            }
        }

        public virtual TEntity GetByKey(Tld key)
        {
            return _unitOfWork.DbContext.Set<TEntity>().Find(key);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.DbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> GetFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> GetFilter(Expression<Func<TEntity, bool>> predicate, params String[] includes)
        {
                if (includes == null)
                    return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).AsEnumerable();
                switch (includes.Count())
                {
                    case 0: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).AsEnumerable();
                    case 1: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).AsEnumerable();
                    case 2: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).AsEnumerable();
                    case 3: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).AsEnumerable();
                    case 4: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).AsEnumerable();
                    case 5: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).AsEnumerable();
                    case 6: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).AsEnumerable();
                    case 7: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).AsEnumerable();
                    case 8: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).Include(includes[7]).AsEnumerable();
                    case 9: return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).Include(includes[7]).Include(includes[8]).AsEnumerable();
                    default: throw new Exception("too much navigational property!");
                }
        }

        public virtual IEnumerable<TEntity> GetPaged<Key>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Key>> keySelector, Int32 pageIndex, Int32 pageCount, bool isAscending = true)
        {
            if (isAscending)
                return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).OrderBy(keySelector).Skip(pageIndex * pageCount).AsEnumerable();
            else
                return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).OrderByDescending(keySelector).Skip(pageIndex * pageCount).AsEnumerable();
        }

        public virtual IEnumerable<TEntity> GetPaged<Key>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, Key>> keySelector, int pageIndex, int pageCount, bool IsAscending = true, params String[] Includes)
        {
            throw new NotImplementedException();
        }

        //是否可以用select来处理导航属性的问题 未验证
        public virtual IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).Select(selector).AsEnumerable();
        }

        public virtual IEnumerable<TResult> Select<TResult, Key>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, Key>> keySelector, bool isAscending = true)
        {
            if (isAscending)
            {
                return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).OrderBy<TEntity, Key>(keySelector).Select<TEntity, TResult>(selector);
            }
            else
            {
                return _unitOfWork.DbContext.Set<TEntity>().Where(predicate).OrderByDescending<TEntity, Key>(keySelector).Select<TEntity, TResult>(selector);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="includes">字符串参数不超过八个</param>
        ///// <returns></returns>
        //public IQueryable<TEntity> GetAllWithNavigationalProperty(params String[] includes)
        //{
        //    if (includes == null)
        //        return GetAll();
        //    switch (includes.Count())
        //    {
        //        case 0: return GetAll();
        //        case 1: return GetAll().Include(includes[0]);
        //        case 2: return GetAll().Include(includes[0]).Include(includes[1]);
        //        case 3: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]);
        //        case 4: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]);
        //        case 5: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]);
        //        case 6: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]);
        //        case 7: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]);
        //        case 8: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).Include(includes[7]);
        //        case 9: return GetAll().Include(includes[0]).Include(includes[1]).Include(includes[2]).Include(includes[3]).Include(includes[4]).Include(includes[5]).Include(includes[6]).Include(includes[7]).Include(includes[8]);
        //        default: throw new Exception("too much navigational property!");
        //    }
        //}
    }
}