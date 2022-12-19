﻿using System.ComponentModel.DataAnnotations;
namespace WebPortalStudent.Models
{
    public class M_Nationality: M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public string Description { get; set; }
       

    }
    public class EM_Nationality : M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public string Description { get; set; }
  

    }
}
