using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;

namespace AspNetCoreWebApiExample.Repositories
{
    /// <summary>
    /// �ϥΪ̸�Ʀs�������A�w�q�򥻪� CRUD �P�����d�߾ާ@�C
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// ���o�Ҧ��ϥΪ̪��`���ơC
        /// </summary>
        /// <returns>�ϥΪ��`�ơC</returns>
        Task<int> GetTotalCountAsync();

        /// <summary>
        /// �̤����P�ƧǰѼƨ��o�ϥΪ̤����M��C
        /// </summary>
        /// <param name="query">�����P�ƧǬd�߰ѼơC</param>
        /// <returns>�������G�C</returns>
        Task<PagedResult<User>> GetPagedAsync(PagedQuery query);

        /// <summary>
        /// �� Id ���o��@�ϥΪ̡C
        /// </summary>
        /// <param name="id">�ϥΪ̰ߤ@�ѧO�X�C</param>
        /// <returns>�ϥΪ̹���A�Y�L�h�^�� null�C</returns>
        Task<User> GetByIdAsync(int id);

        /// <summary>
        /// �s�W�@��ϥΪ̡C
        /// </summary>
        /// <param name="user">�n�s�W���ϥΪ̹���C</param>
        Task AddAsync(User user);

        /// <summary>
        /// ��s�@��ϥΪ̸�ơC
        /// </summary>
        /// <param name="user">�n��s���ϥΪ̹���C</param>
        Task UpdateAsync(User user);

        /// <summary>
        /// �R���@��ϥΪ̡C
        /// </summary>
        /// <param name="user">�n�R�����ϥΪ̹���C</param>
        Task DeleteAsync(User user);
    }
}
