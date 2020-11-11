using AutoMapper;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x =>
            {
                x.AddGlobalIgnore(nameof(BaseDto.ValidationResult));
                x.AddProfile(new DomainToModelProfile());
                x.AddProfile(new ModelToDomainProfile());
            });
        }
    }
}
