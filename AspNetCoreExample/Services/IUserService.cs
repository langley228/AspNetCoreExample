using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;

namespace AspNetCoreWebApiExample.Services
{
    /// <summary>
    /// 使用者服務介面，定義使用者相關的商業邏輯操作。
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 依分頁與排序參數取得使用者分頁清單。
        /// </summary>
        /// <param name="query">分頁與排序查詢參數。</param>
        /// <returns>分頁結果（UserViewModel）。</returns>
        Task<PagedResult<UserViewModel>> GetPagedAsync(PagedQuery query);

        /// <summary>
        /// 依 Id 取得單一使用者。
        /// </summary>
        /// <param name="id">使用者唯一識別碼。</param>
        /// <returns>使用者 ViewModel，若無則回傳 null。</returns>
        Task<UserViewModel> GetByIdAsync(int id);

        /// <summary>
        /// 新增一位使用者。
        /// </summary>
        /// <param name="user">要新增的使用者 ViewModel。</param>
        /// <returns>新增後的使用者 ViewModel（含 Id）。</returns>
        Task<UserViewModel> CreateAsync(UserViewModel user);

        /// <summary>
        /// 更新一位使用者資料。
        /// </summary>
        /// <param name="id">使用者唯一識別碼。</param>
        /// <param name="user">要更新的使用者 ViewModel。</param>
        /// <returns>更新成功回傳 true，否則 false。</returns>
        Task<bool> UpdateAsync(int id, UserViewModel user);

        /// <summary>
        /// 刪除一位使用者。
        /// </summary>
        /// <param name="id">使用者唯一識別碼。</param>
        /// <returns>刪除成功回傳 true，否則 false。</returns>
        Task<bool> DeleteAsync(int id);
    }
}
