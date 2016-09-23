using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public interface IRepository<TEntity, Tld> : IReadOnlyRepository<TEntity, Tld> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 删除聚合
        /// </summary>
        /// <param name="entity"></param>
        void RemoveCascaded(TEntity entity);

        /// <summary>
        /// 非级联删除
        /// </summary>
        /// <param name="entity"></param>
        void RemoveNonCascaded(TEntity entity);

        /// <summary>
        /// 删除聚合
        /// </summary>
        /// <param name="t"></param>
        void RemoveCascaded(Tld t);

        /// <summary>
        /// 非级联删除
        /// </summary>
        /// <param name="t"></param>
        void RemoveNonCascaded(Tld t);

        /// <summary>
        /// 修改聚合
        /// </summary>
        /// <param name="entity"></param>
        void Save(TEntity entity);
    }
}
