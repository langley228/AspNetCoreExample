using System;

namespace AspNetCoreWebApiExample.Models
{
    public class InvalidSortFieldException : Exception
    {
        public InvalidSortFieldException(string field)
            : base($"排序欄位 '{field}' 不存在。")
        {
        }
    }
}
