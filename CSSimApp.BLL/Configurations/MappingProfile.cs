using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSSimApp.BLL.Dtos;
using CSSimApp.DAL.Models;

namespace CSSimApp.BLL.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Size, SizeDto>();
            CreateMap<SizeDto, Size>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Material, MaterialDto>();
            CreateMap<MaterialDto, Material>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Bouquet, BouquetDto>();
            CreateMap<BouquetDto, Bouquet>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<BouquetMaterial, BouquetMaterialDto>();
            CreateMap<BouquetMaterialDto, Bouquet>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
