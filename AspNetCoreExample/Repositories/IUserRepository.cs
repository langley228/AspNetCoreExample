using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;

namespace AspNetCoreWebApiExample.Repositories
{
    /// <summary>
    /// 使用者資料存取介面，定義基本的 CRUD 與分頁查詢操作。
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 取得所有使用者的總筆數。
        /// </summary>
        /// <returns>使用者總數。</returns>
        Task<int> GetTotalCountAsync();

        /// <summary>
        /// 依分頁與排序參數取得使用者分頁清單。
        /// </summary>
        /// <param name="query">分頁與排序查詢參數。</param>
        /// <returns>分頁結果。</returns>
        Task<PagedResult<User>> GetPagedAsync(PagedQuery query);

        /// <summary>
        /// 依 Id 取得單一使用者。
        /// </summary>
        /// <param name="id">使用者唯一識別碼。</param>
        /// <returns>使用者實體，若無則回傳 null。</returns>
        Task<User> GetByIdAsync(int id);

        /// <summary>
        /// 新增一位使用者。
        /// </summary>
        /// <param name="user">要新增的使用者實體。</param>
        Task AddAsync(User user);

        /// <summary>
        /// 更新一位使用者資料。
        /// </summary>
        /// <param name="user">要更新的使用者實體。</param>
        Task UpdateAsync(User user);

        /// <summary>
        /// 刪除一位使用者。
        /// </summary>
        /// <param name="user">要刪除的使用者實體。</param>
        Task DeleteAsync(User user);
    }
}
