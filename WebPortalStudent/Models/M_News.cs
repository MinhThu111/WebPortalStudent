namespace WebPortalStudent.Models
{
    public partial class M_News: M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public int? newscategoryid { get; set; }
        public string title { get; set; }
        public string titleSlug { get; set; }
        /// <summary>
        /// id lấy từ person. Xác định GVCN
        /// </summary>
        public string description { get; set; }
        public string avatarurl { get; set; }
        public string detail { get; set; }
     

    }
}
