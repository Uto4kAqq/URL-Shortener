using AutoMapper;
using URL_Shortener.Client.Data.ViewModels;
using URL_Shortener.Data.Models;

namespace URL_Shortener.Client.Data.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Url, GetUrlVM>().ReverseMap();
            CreateMap<AppUser, GetUserVM>().ReverseMap();
        }
    }
}
