using System;
using System.Collections.Generic;
using AutoMapper;
using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Interfaces.Services;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.Application
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountApplicationService(IAccountRepository accountRepository, IAccountService accountService, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
            _mapper = mapper;
        }

        public void Add(AccountModel model)
        {
            var dto = _mapper.Map<AccountDto>(model);
            _accountService.Add(dto);
        }

        public PaginedModel<AccountModel> Get(Filter filter)
        {
            var (totalItems, entities) = _accountRepository.Get(filter);
            return new PaginedModel<AccountModel>(totalItems, _mapper.Map<IList<AccountModel>>(entities));
        }

        public AccountModel GetById(Guid id)
        {
            var entity = _accountRepository.GetById(id);
            return _mapper.Map<AccountModel>(entity);
        }

        public void Remove(Guid id)
        {
            _accountService.Remove(id);
        }
    }
}
