using AutoMapper;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Dictionaries;
using IMuaythai.Models.Locations;

namespace IMuaythai.Dictionaries
{
    public class DictionariesProfile:Profile
    {
        public DictionariesProfile()
        {
            CreateMap<Round, RoundModel>();
            CreateMap<KhanLevel, KhanLevelModel>();
            CreateMap<KhanLevelModel, KhanLevel>();

            CreateMap<ContestRange, ContestRangeModel>();
            CreateMap<ContestRangeModel, ContestRange>();

            CreateMap<ContestType, ContestTypeModel>();
            CreateMap<ContestTypeModel, ContestType>();

            CreateMap<WeightAgeCategory, WeightAgeCategoryModel>();
            CreateMap<WeightAgeCategoryModel, WeightAgeCategory>();


            CreateMap<ContestTypePoints, ContestPointsModel>()
                .ForMember(dest => dest.ContestRange,
                    opt => opt.MapFrom(src => src.ContestRange ?? new ContestRange()))
                .ForMember(dest => dest.ContestType,
                    opt => opt.MapFrom(src => src.ContestType ?? new ContestType()));

            CreateMap<FightStructure, FightStructureModel>()
                .ForMember(dest => dest.WeightAgeCategory,
                    opt => opt.MapFrom(src => src.WeightAgeCategory ?? new WeightAgeCategory()))
                .ForMember(dest => dest.Round,
                    opt => opt.MapFrom(src => src.Round ?? new Round()));

            CreateMap<FightStructureModel, FightStructure>()
                .ForMember(dest => dest.ContestCategories, opt => opt.Ignore())
                .ForMember(dest => dest.Fights, opt => opt.Ignore())
                .ForMember(dest => dest.Round, opt => opt.Ignore())
                .ForMember(dest => dest.WeightAgeCategory, opt => opt.Ignore());




            CreateMap<ContestCategory, ContestCategoryModel>()
                .ForMember(dest => dest.ContestPoints,
                    opt => opt.MapFrom(src => src.ContestTypePoints ?? new ContestTypePoints()))
                .ForMember(dest => dest.FightStructure,
                    opt => opt.MapFrom(src => src.FightStructure ?? new FightStructure()));


            CreateMap<ContestCategoryModel, ContestCategory>();
            CreateMap<ContestPointsModel, ContestTypePoints>();
            CreateMap<ContestRangeModel, ContestRange>();
            CreateMap<RoundModel, Round>();
            CreateMap<Round, RoundModel>();
            CreateMap<Country, CountryModel>();

        }
    }
}