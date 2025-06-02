using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;

namespace AspNetCoreWebApiExample.Repositories
{
    /// <summary>
    /// 使用者資料存取實作，負責與資料庫進行 CRUD 及分頁查詢。
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// 建構子，注入資料庫內容。
        /// </summary>
        /// <param name="context">資料庫內容物件</param>
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得所有使用者的總筆數。
        /// </summary>
        /// <returns>使用者總數。</returns>
        public async Task<int> GetTotalCountAsync()
            => await _context.Users.CountAsync();

        /// <summary>
        /// 依分頁與排序參數取得使用者分頁清單。
        /// </summary>
        /// <param name="query">分頁與排序查詢參數。</param>
        /// <returns>分頁結果。</returns>
        public async Task<PagedResult<User>> GetPagedAsync(PagedQuery query)
        {
            var usersQuery = _context.Users.AsQueryable();

            // 使用泛型擴充方法動態排序
            if (!string.IsNullOrEmpty(query.SortBy))
                usersQuery = usersQuery.OrderByProperty(query.SortBy, query.Desc);
            else
                usersQuery = usersQuery.OrderBy(u => u.Id);

            var total = await usersQuery.CountAsync();
            var data = await usersQuery
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PagedResult<User>
            {
                TotalCount = total,
                Page = query.Page,
                PageSize = query.PageSize,
                Data = data
            };
        }

        /// <summary>
        /// 依 Id 取得單一使用者。
        /// </summary>
        /// <param name="id">使用者唯一識別碼。</param>
        /// <returns>使用者實體，若無則回傳 null。</returns>
        public async Task<User> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        /// <summary>
        /// 新增一位使用者。
        /// </summary>
        /// <param name="user">要新增的使用者實體。</param>
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 更新一位使用者資料。
        /// </summary>
        /// <param name="user">要更新的使用者實體。</param>
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 刪除一位使用者。
        /// </summary>
        /// <param name="user">要刪除的使用者實體。</param>
        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
