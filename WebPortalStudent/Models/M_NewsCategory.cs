

namespace WebPortalStudent.Models
{
    public partial class M_NewsCategory:M_BaseModel.BaseCustom
    {
        
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 0:Giới thiệu;1:Tin tức;2:Thông báo
        /// </summary>
        public int? Type { get; set; }


    }
}
