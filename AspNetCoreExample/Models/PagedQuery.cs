namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// 分頁與排序查詢參數。
    /// </summary>
    public class PagedQuery
    {
        /// <summary>
        /// 頁碼（從 1 開始）。
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 每頁筆數。
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 排序欄位名稱（如 "Name"、"Email"）。
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// 是否為遞減排序（true: 遞減，false: 遞增）。
        /// </summary>
        public bool Desc { get; set; } = false;
    }
}
