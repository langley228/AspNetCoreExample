using System.Collections.Generic;

namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// 分頁查詢的回傳結果模型。
    /// </summary>
    /// <typeparam name="T">資料項目的型別。</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// 總資料筆數。
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 目前頁碼。
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每頁筆數。
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 分頁後的資料清單。
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
