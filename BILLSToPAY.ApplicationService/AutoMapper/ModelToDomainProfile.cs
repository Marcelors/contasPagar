using AutoMapper;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Extensions;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.AutoMapper
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<RuleModel, RuleDto>()
                .ForMember(x => x.Type, m => m.MapFrom(a => a.Type.HasValue ? (RuleType)a.Type.Value : (RuleType?)null));

            CreateMap<AccountModel, AccountDto>();
        }
    }
}
