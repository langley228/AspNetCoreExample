using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// IQueryable �X�R��k�A���ѰʺA�Ƨǥ\��C
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// �ھګ��w�ݩʦW�ٶi��ʺA�ƧǡC
        /// </summary>
        /// <typeparam name="T">��ƨӷ������O�C</typeparam>
        /// <param name="source">�n�ƧǪ� IQueryable ��ƨӷ��C</param>
        /// <param name="propertyName">�Ƨ����W�١]�ݩʦW�١A�Ϥ��j�p�g�P�_�ҥi�^�C</param>
        /// <param name="desc">�O�_������ƧǡA�w�]�� false�]���W�^�C</param>
        /// <returns>�Ƨǫ᪺ IQueryable�C</returns>
        /// <exception cref="InvalidSortFieldException">����w���ݩʤ��s�b�ɩߥX�C</exception>
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
