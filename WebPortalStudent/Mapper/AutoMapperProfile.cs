﻿using AutoMapper;
using WebPortalStudent.Models;
using WebPortalStudent.ViewModels;

namespace WebPortalStudent.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region SelectDropDown
            //CreateMap<M_Product, VM_SelectDropDown>();
            CreateMap<M_PersonType, VM_SelectDropDown>();
            CreateMap<M_Nationality, VM_SelectDropDown>();
            CreateMap<M_Religion, VM_SelectDropDown>();
            CreateMap<M_Folk, VM_SelectDropDown>();
            #endregion

            CreateMap<M_Person, EM_Person>();
            //#region Account Person
            ////CreateMap<M_Person, EM_Person>()
            ////.ForMember(des => des.imageUrl, opt => opt.MapFrom(source => source.imageObj.mediumUrl));
            ////CreateMap<M_PersonWarehouse, VM_AccountInfo>()
            ////.ForMember(des => des.accountId, opt => opt.MapFrom(source => source.personObj.accountObj.id))
            ////.ForMember(des => des.userName, opt => opt.MapFrom(source => source.personObj.accountObj.userName));
            //#endregion

        }
    }
}
