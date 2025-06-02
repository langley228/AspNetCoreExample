namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// 使用者檢視模型（View Model）。
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// 使用者唯一識別碼。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 使用者姓名。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 使用者電子郵件。
        /// </summary>
        public string Email { get; set; }
    }
}
