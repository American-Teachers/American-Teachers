using AtApi.Model;
using AtApi.Models.UserViewModels;
using AtApi.Service.Identity;
using AutoMapper;

namespace AtApi.Mappings
{
    public class UserMappingsProfile : Profile
    {

        public UserMappingsProfile()
        {
            CreateMap<RegisterRequest, ApplicationUser>()
                .ForMember(d=>d.UserName, o => o.MapFrom(s=>s.Email))          
                ;
            CreateMap<ExternalRegisterRequest, ApplicationUser>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                ;

            CreateMap< RegisterUserRequest, PersonRequest>()
                .ForMember(d=> d.EmailAddress, o=>o.MapFrom(s=>s.UserName))               
                ;
        
        }
    }
}
