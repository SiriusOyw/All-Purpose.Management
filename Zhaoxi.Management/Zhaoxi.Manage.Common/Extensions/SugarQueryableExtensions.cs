using JetBrains.Annotations;
using SqlSugar;
using System.Linq.Expressions;

namespace Zhaoxi.Manage.Common.Extensions
{
    public static class SugarQueryableExtensions
    {
        /// <summary>
        /// Used for paging. Can be used as an alternative to Skip(...).Take(...) chaining.
        /// </summary>
        public static ISugarQueryable<T> PageBy<T>([NotNull] this ISugarQueryable<T> query, int skipCount, int maxResultCount)
        {
            Check.NotNull(query, nameof(query));

            return query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>
        /// Used for paging. Can be used as an alternative to Skip(...).Take(...) chaining.
        /// </summary>
        public static TQueryable PageBy<T, TQueryable>([NotNull] this TQueryable query, int skipCount, int maxResultCount)
            where TQueryable : ISugarQueryable<T>
        {
            Check.NotNull(query, nameof(query));

            return (TQueryable)query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>
        /// Filters a <see cref="ISugarQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
        public static ISugarQueryable<T> WhereIf<T>([NotNull] this ISugarQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            Check.NotNull(query, nameof(query));

            return condition
                ? query.Where(predicate)
                : query;
        }

        /// <summary>
        /// Filters a <see cref="ISugarQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
        public static TQueryable WhereIf<T, TQueryable>([NotNull] this TQueryable query, bool condition, Expression<Func<T, bool>> predicate)
            where TQueryable : ISugarQueryable<T>
        {
            Check.NotNull(query, nameof(query));

            return condition
                ? (TQueryable)query.Where(predicate)
                : query;
        }

        /// <summary>
        /// Filters a <see cref="ISugarQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
        //public static ISugarQueryable<T> WhereIf<T>([NotNull] this ISugarQueryable<T> query, bool condition, Expression<Func<T, int, bool>> predicate)
        //{
        //    Check.NotNull(query, nameof(query));

        //    return condition
        //        ? query.Where(predicate)
        //        : query;
        //}

        /// <summary>
        /// Filters a <see cref="ISugarQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="predicate">Predicate to filter the query</param>
        /// <returns>Filtered or not filtered query based on <paramref name="condition"/></returns>
        //public static TQueryable WhereIf<T, TQueryable>([NotNull] this TQueryable query, bool condition, Expression<Func<T, int, bool>> predicate)
        //    where TQueryable : ISugarQueryable<T>
        //{
        //    Check.NotNull(query, nameof(query));

        //    return condition
        //        ? (TQueryable)query.Where(predicate)
        //        : query;
        //}

        /// <summary>
        /// Order a <see cref="ISugarQueryable{T}"/> by given predicate if given condition is true.
        /// </summary>
        /// <param name="query">Queryable to apply filtering</param>
        /// <param name="condition">A boolean value</param>
        /// <param name="sorting">Order the query</param>
        /// <returns>Order or not order query based on <paramref name="condition"/></returns>
        //public static TQueryable OrderByIf<T, TQueryable>([NotNull] this TQueryable query, bool condition, string sorting)
        //    where TQueryable : ISugarQueryable<T>
        //{
        //    Check.NotNull(query, nameof(query));

        //    return condition
        //        ? (TQueryable)Dynamic.Core.DynamicQueryableExtensions.OrderBy(query, sorting)
        //        : query;
        //}
    }
}
