using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Institutions;

namespace IMuaythai.Institutions
{
    public class InstitutionsProfile:Profile
    {
        public InstitutionsProfile()
        {
            CreateMap<Institution, InstitutionResponseModel>();
            CreateMap<Institution, GymResponseModel>();

            CreateMap<InstitutionUpdateModel, Institution>()
                .ForMember(dest => dest.InstitutionDocumentsMappings, opt => opt.Ignore())
                .ForMember(dest => dest.ContestRequests, opt => opt.Ignore())
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ForMember(dest => dest.ExecutionBoards, opt => opt.Ignore())
                .ForMember(dest => dest.Contests, opt => opt.Ignore())
                .ForMember(dest => dest.HeadCoach, opt => opt.Ignore());  
        }
    }
}