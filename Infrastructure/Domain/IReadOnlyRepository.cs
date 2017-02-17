using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure
{
    public interface IReadOnlyRepository<T,Tld> where T:IAggregateRoot
    {
        /// <summary>
        /// 
        /// </summary>
        IUnitOfWork UnitOfWork { get; set; }
        
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <returns>返回非空实体集合</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// 按查询条件获取实体集合
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="IsAscending">升序</param>
        /// <returns>返回非空实体集合</returns>
        IEnumerable<T> GetFilter(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 按查询条件获取聚合
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="IsAscending">升序</param>
        /// <param name="Includes">聚合包含的实体</param>
        /// <returns>返回非空聚合</returns>
        IEnumerable<T> GetFilter(Expression<Func<T, bool>> predicate,  params String[] Includes);

        /// <summary>
        /// 按查询条件获取一页实体集合
        /// </summary>
        /// <typeparam name="Key">排序属性</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序条件</param>
        /// <param name="pageIndex">页码（从0开始计数）</param>
        /// <param name="pageCount">每页实体数</param>
        /// <param name="IsAscending">升序</param>
        /// <returns>返回符合条件的实体集合</returns>
        IEnumerable<T> GetPaged<Key>(Expression<Func<T, bool>> predicate, Expression<Func<T, Key>> keySelector, int pageIndex, int pageCount, bool isAscending = true);

        /// <summary>
        /// 按查询条件获取一页聚合
        /// </summary>
        /// <typeparam name="Key">排序属性</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序条件</param>
        /// <param name="pageIndex">页码（从0开始计数）</param>
        /// <param name="pageCount">每页聚合数</param>
        /// <param name="IsAscending">升序</param>
        /// <param name="Includes">聚合包含的实体</param>
        /// <returns>返回符合条件的聚合</returns>
        IEnumerable<T> GetPaged<Key>(Expression<Func<T, bool>> predicate, Expression<Func<T, Key>> keySelector, int pageIndex, int pageCount, bool IsAscending = true, params String[] Includes);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        IEnumerable<TResult> Select<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);

        /// <summary>
        /// 按主键获取实体
        /// </summary>
        /// <param name="key">主键值</param>
        /// <returns>返回实体或者null</returns>
        T GetByKey(Tld key);
    }
}
