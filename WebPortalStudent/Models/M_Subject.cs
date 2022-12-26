namespace WebPortalStudent.Models
{
    public class M_Subject:M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
    }
}
