namespace AspNetCoreWebApiExample.Models
{
    /// <summary>
    /// �����P�ƧǬd�߰ѼơC
    /// </summary>
    public class PagedQuery
    {
        /// <summary>
        /// ���X�]�q 1 �}�l�^�C
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// �C�����ơC
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// �Ƨ����W�١]�p "Name"�B"Email"�^�C
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// �O�_������Ƨǡ]true: ����Afalse: ���W�^�C
        /// </summary>
        public bool Desc { get; set; } = false;
    }
}
