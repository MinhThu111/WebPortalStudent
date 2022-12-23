namespace WebPortalStudent.Models
{
    public partial class M_News: M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public int? NewsCategoryId { get; set; }
        public string Title { get; set; }
        public string TitleSlug { get; set; }
        /// <summary>
        /// id lấy từ person. Xác định GVCN
        /// </summary>
        public string Description { get; set; }
        public string Detail { get; set; }
     

    }
}
