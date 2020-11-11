using System;
using System.Collections.Generic;
using AutoMapper;
using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Interfaces.Services;
using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Extensions;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.Application
{
    public class RuleApplicationService : IRuleApplicationService
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly IRuleService _ruleService;
        private readonly IMapper _mapper;

        public RuleApplicationService(IRuleRepository ruleRepository, IRuleService ruleService, IMapper mapper)
        {
            _ruleRepository = ruleRepository;
            _ruleService = ruleService;
            _mapper = mapper;
        }

        public void Add(RuleModel model)
        {
            var dto = _mapper.Map<RuleDto>(model);
            _ruleService.Add(dto);
        }

        public void Disable(Guid id)
        {
            _ruleService.Disable(id);
        }

        public void Enable(Guid id)
        {
            _ruleService.Enable(id);
        }

        public PaginedModel<RuleModel> Get(Filter filter)
        {
            var (totalItems, entities) = _ruleRepository.Get(filter);
            return new PaginedModel<RuleModel>(totalItems, _mapper.Map<IList<RuleModel>>(entities));
        }

        public RuleModel GetById(Guid id)
        {
            var entity = _ruleRepository.GetById(id);
            return _mapper.Map<RuleModel>(entity);
        }

        public IList<EnumModel<short>> GetTypes()
        {
            var list = EnumExtension.EnumToModel<short, RuleType>();
            return list;
        }

        public void Remove(Guid id)
        {
            _ruleService.Remove(id);
        }
    }
}
