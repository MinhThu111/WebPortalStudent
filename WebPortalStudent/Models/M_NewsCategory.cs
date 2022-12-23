

namespace WebPortalStudent.Models
{
    public partial class M_NewsCategory
    {

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 0:Giới thiệu;1:Tin tức;2:Thông báo
        /// </summary>
        public int? Type { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime Timer { get; set; }
        public List<M_NewsCategory> ChildMenu { get; set; }


    }
}
