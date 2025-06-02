using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// IQueryable 擴充方法，提供動態排序功能。
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 根據指定屬性名稱進行動態排序。
        /// </summary>
        /// <typeparam name="T">資料來源的型別。</typeparam>
        /// <param name="source">要排序的 IQueryable 資料來源。</param>
        /// <param name="propertyName">排序欄位名稱（屬性名稱，區分大小寫與否皆可）。</param>
        /// <param name="desc">是否為遞減排序，預設為 false（遞增）。</param>
        /// <returns>排序後的 IQueryable。</returns>
        /// <exception cref="InvalidSortFieldException">當指定的屬性不存在時拋出。</exception>
        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string propertyName, bool desc = false)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                return source;

            var property = typeof(T).GetProperty(propertyName, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (property == null)
                throw new InvalidSortFieldException(propertyName);

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            string methodName = desc ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExp)
            );
            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
