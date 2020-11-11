using System;
using BILLSToPAY.Domain.DTO;

namespace BILLSToPAY.Domain.Interfaces.Services
{
    public interface IRuleService
    {
        void Add(RuleDto dto);
        void Remove(Guid id);
        void Enable(Guid id);
        void Disable(Guid id);
    }
}
