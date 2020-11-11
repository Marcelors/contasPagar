using System;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Interfaces.Services;
using BILLSToPAY.Domain.Shared.Notification;
using BILLSToPAY.Domain.Shared.Resources;
using MediatR;

namespace BILLSToPAY.Domain.Services
{
    public class RuleService : ServiceBase, IRuleService
    {
        private readonly IRuleRepository _ruleRepository;

        public RuleService(IUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications, IRuleRepository ruleRepository) : base(uow, bus, notifications)
        {
            _ruleRepository = ruleRepository;
        }

        public void Add(RuleDto dto)
        {
            if (!dto.IsValid())
            {
                NotifyValidationError(dto);
                return;
            }

            var entity = new Rule(days: dto.Days.Value, type: dto.Type.Value, interestPerDay: dto.InterestPerDay.Value, penalty: dto.Penalty.Value);
            _ruleRepository.Add(entity);

            Commit();
        }

        public void Disable(Guid id)
        {
            var entity = _ruleRepository.GetById(id);

            if(entity == null)
            {
                NotifyError(DomainError.RuleNotFound);
                return;
            }

            entity.Disable();
            _ruleRepository.Update(entity);

            Commit();
        }

        public void Enable(Guid id)
        {
            var entity = _ruleRepository.GetById(id);

            if (entity == null)
            {
                NotifyError(DomainError.RuleNotFound);
                return;
            }

            entity.Enable();
            _ruleRepository.Update(entity);

            Commit();
        }

        public void Remove(Guid id)
        {
            _ruleRepository.Remove(id);
            Commit();
        }
    }
}
