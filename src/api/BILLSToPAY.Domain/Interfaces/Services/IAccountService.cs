using System;
using BILLSToPAY.Domain.DTO;

namespace BILLSToPAY.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        void Add(AccountDto dto);
        void Remove(Guid id);
    }
}
