using AutoMapper;
using Volcafe.Application.DTO;
using Volcafe.Core.Entities;

namespace Volcafe.Web.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Products, ProductDto>().
            //   ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            //  .ForMember(p => p.ProductType, pt => pt.MapFrom(p => p.ProductType.Name))
            //  .ForMember(p=>p.PictureUrl,pt=>pt.MapFrom<ProductUrlResolvers>());
            CreateMap<User, UserDTO>()
                .ForMember(d => d.UserRole, opt => opt.MapFrom(s => s.UserRole.Role))
                .ForMember(d => d.UserType, opt => opt.MapFrom(s => s.UserType.Type));
            CreateMap<ContractDetail, ContractDetailDTO>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.Status));
        }
    }
}
