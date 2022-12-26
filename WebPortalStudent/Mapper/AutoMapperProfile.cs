using AutoMapper;
using WebPortalStudent.Models;
using WebPortalStudent.ViewModels;

namespace WebPortalStudent.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region SelectDropDown
            #endregion

            CreateMap<M_Person, EM_Person>();

        }
    }
}
