﻿namespace WebPortalStudent.Models
{
    public class M_Ward:M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public string WardCode { get; set; }
        public int DistrictId { get; set; }
    }
}
