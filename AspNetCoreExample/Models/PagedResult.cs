using System.Collections.Generic;

namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// �����d�ߪ��^�ǵ��G�ҫ��C
    /// </summary>
    /// <typeparam name="T">��ƶ��ت����O�C</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// �`��Ƶ��ơC
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// �ثe���X�C
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// �C�����ơC
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// �����᪺��ƲM��C
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
