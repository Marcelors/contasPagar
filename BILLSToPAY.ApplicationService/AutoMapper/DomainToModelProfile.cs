using System;
using AutoMapper;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Shared.Extensions;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.AutoMapper
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<Rule, RuleModel>()
              .ForMember(x => x.Type, m => m.MapFrom(a => (short)a.Type))
              .ForMember(x => x.TypeModel, m => m.MapFrom(a => new EnumModel<short>((short)a.Type, a.Type.GetDescription())));

            CreateMap<Account, AccountModel>();
        }
    }
}
