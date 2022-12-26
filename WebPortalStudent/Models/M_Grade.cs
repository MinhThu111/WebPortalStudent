namespace WebPortalStudent.Models
{
    public class M_Grade:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gradeCode { get; set; }
        /// <summary>
        /// Id lấy từ person. Xác định GVCN
        /// </summary>
        public int? teacherId { get; set; }
        public string remark { get; set; }
        public M_Person teacherObj { get; set; }
    }
}
