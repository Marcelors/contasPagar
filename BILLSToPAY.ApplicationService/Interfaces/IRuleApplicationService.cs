using System;
using System.Collections.Generic;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.Interfaces
{
    public interface IRuleApplicationService
    {
        void Add(RuleModel model);
        void Remove(Guid id);
        void Enable(Guid id);
        void Disable(Guid id);
        RuleModel GetById(Guid id);
        PaginedModel<RuleModel> Get(Filter filter);
        IList<EnumModel<short>> GetTypes();
    }
}
