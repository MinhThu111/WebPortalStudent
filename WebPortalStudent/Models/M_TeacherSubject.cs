namespace WebPortalStudent.Models
{
    public class M_TeacherSubject:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public int? teacherId { get; set; }
        public int? subjectId { get; set; }
        public string remark { get; set; }
        public M_Subject subjectObj { get; set; }
        public M_Person teacherObj { get; set; }
    }
}
