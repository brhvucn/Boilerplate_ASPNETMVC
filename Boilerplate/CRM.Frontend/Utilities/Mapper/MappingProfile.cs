using AutoMapper;
using CRM.Domain.Dto;
using CRM.Domain.Entities;
using CRM.Domain.Request.Company;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CRM.Frontend.Utilities.Mapper
{
    //This class determines how to map between different ojects. This is done with the help from the nuGet package AutoMapper
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ReverseMap();
            CreateMap<Company, CreateCompanyRequest>()
                 .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ReverseMap();
        }
    }
}
