using AutoMapper;
using back_end.Data;
using back_end.Models;

namespace ShopAPI.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Authentication, AuthenticationModel>().ReverseMap();
            CreateMap<Proxy, ProxyModel>().ReverseMap();
            CreateMap<General, GeneralModel>().ReverseMap();
            CreateMap<Server, InputModel>().ReverseMap();
            CreateMap<InputServerModel, InputModel>().ReverseMap();
            CreateMap<Server, InputServerModel>().ReverseMap();
        }
    }
}
