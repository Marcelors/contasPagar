using System;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.Interfaces
{
    public interface IAccountApplicationService
    {
        void Add(AccountModel model);
        void Remove(Guid id);
        AccountModel GetById(Guid id);
        PaginedModel<AccountModel> Get(Filter filter);
    }
}
