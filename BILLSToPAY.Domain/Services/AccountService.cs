using System;
using System.Collections.Generic;
using System.Linq;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Interfaces.Services;
using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Notification;
using MediatR;

namespace BILLSToPAY.Domain.Services
{
    public class AccountService : ServiceBase, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRuleRepository _ruleRepository;

        public AccountService(IUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications,
            IAccountRepository accountRepository,
            IRuleRepository ruleRepository) : base(uow, bus, notifications)
        {
            _accountRepository = accountRepository;
            _ruleRepository = ruleRepository;
        }

        public void Add(AccountDto dto)
        {
            if (!dto.IsValid())
            {
                NotifyValidationError(dto);
                return;
            }

            (int days, decimal correctedValue, Rule rule) = ApplyRules(dto);

            var entity = new Account(name: dto.Name,
                                    originalValue: dto.OriginalValue.Value,
                                    paymentDate: dto.PaymentDate.Value,
                                    dueDate: dto.DueDate.Value,
                                    correctedValue: correctedValue,
                                    rule: rule,
                                    numberOfDaysLate: days
                                    );

            _accountRepository.Add(entity);

            Commit();
        }

        private (int days, decimal correctedValue, Rule rule) ApplyRules(AccountDto dto)
        {
            var rules = _ruleRepository.GetActives();

            if(rules == null || !rules.Any())
            {
                return (days: 0, correctedValue: dto.OriginalValue.Value, rule: null);
            }

            var days = dto.PaymentDate.Value.Subtract(dto.DueDate.Value).Days;

            if(days <= 0)
            {
                return (days: 0, correctedValue: dto.OriginalValue.Value, rule: null);
            }

            var rule = GetRule(days, rules);

            if(rule == null)
            {
                return (days: days, correctedValue: dto.OriginalValue.Value, rule: null);
            }

            var penaltyValue = (dto.OriginalValue.Value * rule.Penalty) / 100;

            var penaltyPerDayValue = ((dto.OriginalValue.Value * rule.InterestPerDay) / 100) * days;

            var value = dto.OriginalValue.Value + penaltyValue + penaltyPerDayValue;

            return (days: days, correctedValue: value, rule: rule);

        }

        private Rule GetRule(int days, IList<Rule> rules)
        {
            var rule = rules.Where(x => x.Type == RuleType.UpUntil)
                .OrderBy(x => x.Days)
                .FirstOrDefault(x => days <= x.Days);

            if(rule != null)
            {
                return rule;
            }

            rule = rules.Where(x => x.Type == RuleType.After)
                .OrderByDescending(x => x.Days)
                .FirstOrDefault(x => days > x.Days);

            return rule;
        }

        public void Remove(Guid id)
        {
            _accountRepository.Remove(id);

            Commit();
        }
    }
}
