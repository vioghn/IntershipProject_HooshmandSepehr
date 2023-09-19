using AutoMapper;
using Purse.Application.Dtos;
using Purse.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Purse.Application.Mapping
{
    public static class EntityToDtoMapper
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring 
                cfg.CreateMap<Company, CompanyDto>().ReverseMap();
                cfg.CreateMap<PurseM, PurseDto>().ReverseMap();
                cfg.CreateMap<Transaction, TransactionDto>().ReverseMap(); 
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Voacher, VoacherDto>().ReverseMap();

            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }   
}
*/

namespace Purse.Application.Mapping
{
    public class PurseMappingProfile : Profile
    {
        public PurseMappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<PurseM, PurseDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Voacher, VoacherDto>().ReverseMap();
        }
    }
}


