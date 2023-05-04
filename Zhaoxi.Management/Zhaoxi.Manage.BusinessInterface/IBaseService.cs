using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Manage.BusinessInterface
{
    /// <summary>
    /// 提供的就是业务逻辑的基础实现
    /// 提供的公共逻辑--通用的增删改查
    /// </summary>
    public interface IBaseService
    {
        #region Query

        T Find<T>(int id) where T : class;

        Task<T> FindAsync<T>(int id) where T : class;

        [Obsolete("尽量避免使用，using 带表达式目录树的 代替")]
        ISugarQueryable<T> Set<T>() where T : class;

        ISugarQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        PagingData<T> QueryPage<T>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, object>> funcOrderby, bool isAsc = true) where T : class;
        #endregion

        #region Add

        T Insert<T>(T t) where T : class, new();

        Task<T> InsertAsync<T>(T t) where T : class, new();

        Task<bool> InsertList<T>(List<T> tList) where T : class, new();
        #endregion


        #region Update
        
        void Update<T>(T t) where T : class, new();

        Task UpdateAsync<T>(T t) where T : class, new();

        void Update<T>(List<T> tList) where T : class, new();
        #endregion


        #region Delete

        bool Delete<T>(object pId) where T : class, new();

        Task<bool> DeleteAsync<T>(object pId) where T : class, new();

        void Delete<T>(T t) where T : class, new();

        void Delete<T>(List<T> tList) where T : class;
        #endregion


        #region Other

        ISugarQueryable<T> ExcuteQuery<T>(string sql) where T : class, new();

        #endregion

    }
}
