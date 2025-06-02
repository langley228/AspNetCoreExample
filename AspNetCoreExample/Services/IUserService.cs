using System.Threading.Tasks;
using AspNetCoreWebApiExample.Models;

namespace AspNetCoreWebApiExample.Services
{
    /// <summary>
    /// �ϥΪ̪A�Ȥ����A�w�q�ϥΪ̬������ӷ~�޿�ާ@�C
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// �̤����P�ƧǰѼƨ��o�ϥΪ̤����M��C
        /// </summary>
        /// <param name="query">�����P�ƧǬd�߰ѼơC</param>
        /// <returns>�������G�]UserViewModel�^�C</returns>
        Task<PagedResult<UserViewModel>> GetPagedAsync(PagedQuery query);

        /// <summary>
        /// �� Id ���o��@�ϥΪ̡C
        /// </summary>
        /// <param name="id">�ϥΪ̰ߤ@�ѧO�X�C</param>
        /// <returns>�ϥΪ� ViewModel�A�Y�L�h�^�� null�C</returns>
        Task<UserViewModel> GetByIdAsync(int id);

        /// <summary>
        /// �s�W�@��ϥΪ̡C
        /// </summary>
        /// <param name="user">�n�s�W���ϥΪ� ViewModel�C</param>
        /// <returns>�s�W�᪺�ϥΪ� ViewModel�]�t Id�^�C</returns>
        Task<UserViewModel> CreateAsync(UserViewModel user);

        /// <summary>
        /// ��s�@��ϥΪ̸�ơC
        /// </summary>
        /// <param name="id">�ϥΪ̰ߤ@�ѧO�X�C</param>
        /// <param name="user">�n��s���ϥΪ� ViewModel�C</param>
        /// <returns>��s���\�^�� true�A�_�h false�C</returns>
        Task<bool> UpdateAsync(int id, UserViewModel user);

        /// <summary>
        /// �R���@��ϥΪ̡C
        /// </summary>
        /// <param name="id">�ϥΪ̰ߤ@�ѧO�X�C</param>
        /// <returns>�R�����\�^�� true�A�_�h false�C</returns>
        Task<bool> DeleteAsync(int id);
    }
}
