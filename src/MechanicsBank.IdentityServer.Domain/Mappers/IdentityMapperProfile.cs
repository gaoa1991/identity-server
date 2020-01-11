using AutoMapper;
using MechanicsBank.IdentityServer.Data.Entities.Common;
using MechanicsBank.IdentityServer.Data.Entities.Identity;
using MechanicsBank.IdentityServer.Domain.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MechanicsBank.IdentityServer.Domain.Mappers
{
    public class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            CreateMap<User, UserDto>(MemberList.Destination);
            CreateMap<PagedList<User>, UsersDto>(MemberList.Destination)
                .ForMember(x => x.Users,
                    opt => opt.MapFrom(src => src.Data));

            //role model
            CreateMap<Role, RoleDto>(MemberList.Destination);

            CreateMap<User, User>(MemberList.Destination)
                .ForMember(x => x.SecurityStamp, opt => opt.Ignore());

            // model to entity
            CreateMap<UserDto, User>(MemberList.Source);
            CreateMap<RoleDto, Role>(MemberList.Destination);
        }
    }
}
