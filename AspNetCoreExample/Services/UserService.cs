using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;
using AspNetCoreWebApiExample.Repositories;

namespace AspNetCoreWebApiExample.Services
{
    /// <summary>
    /// 使用者服務層，負責處理 User 相關的商業邏輯與 Entity/ViewModel 轉換。
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        /// <summary>
        /// 建構子，注入使用者資料儲存庫。
        /// </summary>
        /// <param name="repo">使用者資料儲存庫介面</param>
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// 取得分頁的使用者清單（含排序）。
        /// </summary>
        /// <param name="query">分頁與排序查詢參數</param>
        /// <returns>分頁結果（UserViewModel）</returns>
        public async Task<PagedResult<UserViewModel>> GetPagedAsync(PagedQuery query)
        {
            var paged = await _repo.GetPagedAsync(query);
            return new PagedResult<UserViewModel>
            {
                TotalCount = paged.TotalCount,
                Page = paged.Page,
                PageSize = paged.PageSize,
                Data = paged.Data.Select(ToViewModel)
            };
        }

        /// <summary>
        /// 依 Id 取得單一使用者。
        /// </summary>
        /// <param name="id">使用者唯一識別碼</param>
        /// <returns>使用者 ViewModel，若無則回傳 null</returns>
        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? null : ToViewModel(user);
        }

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="userViewModel">使用者 ViewModel</param>
        /// <returns>新增後的使用者 ViewModel（含 Id）</returns>
        public async Task<UserViewModel> CreateAsync(UserViewModel userViewModel)
        {
            var user = ToEntity(userViewModel);
            await _repo.AddAsync(user);
            return ToViewModel(user);
        }

        /// <summary>
        /// 更新使用者資料。
        /// </summary>
        /// <param name="id">使用者唯一識別碼</param>
        /// <param name="userViewModel">使用者 ViewModel</param>
        /// <returns>更新成功回傳 true，否則 false</returns>
        public async Task<bool> UpdateAsync(int id, UserViewModel userViewModel)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Name = userViewModel.Name;
            existing.Email = userViewModel.Email;
            await _repo.UpdateAsync(existing);
            return true;
        }

        /// <summary>
        /// 刪除使用者。
        /// </summary>
        /// <param name="id">使用者唯一識別碼</param>
        /// <returns>刪除成功回傳 true，否則 false</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;
            await _repo.DeleteAsync(user);
            return true;
        }

        /// <summary>
        /// 將 User Entity 轉換為 UserViewModel。
        /// </summary>
        /// <param name="user">User Entity</param>
        /// <returns>UserViewModel</returns>
        private static UserViewModel ToViewModel(User user) =>
            new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

        /// <summary>
        /// 將 UserViewModel 轉換為 User Entity（僅建立用）。
        /// </summary>
        /// <param name="vm">UserViewModel</param>
        /// <returns>User Entity</returns>
        private static User ToEntity(UserViewModel vm) =>
            new User
            {
                Name = vm.Name,
                Email = vm.Email
            };
    }
}
