using System;
using System.Linq;
using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Test.Builder;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Integration.ApplicationService
{
    public class AccountApplicationServiceTest : TestIntegrationBase
    {
        private readonly IAccountApplicationService _accountApplicationService;
        private readonly IAccountRepository _accountRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountApplicationServiceTest() : base()
        {
            CreateScope();

            _accountApplicationService = GetIntanceScope<IAccountApplicationService>();
            _accountRepository = GetInstance<IAccountRepository>();
            _ruleRepository = GetIntanceScope<IRuleRepository>();
            _unitOfWork = GetIntanceScope<IUnitOfWork>();
        }

        [Fact]
        public void AccountApplicationService_Add()
        {
            var model = new AccountModel
            {
                OriginalValue = 10,
                PaymentDate = DateTime.Now.Date,
                DueDate = DateTime.Now.AddDays(-2).Date,
                Name = "test"
            };

            var rule = new RuleBuilder().WithDays(3).WithType(RuleType.UpUntil).WithPenalty(2).WithInterestPerDay(0.2m).Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _accountApplicationService.Add(model);

            var result = _accountRepository.Get(new Filter());

            result.entities.Should().HaveCount(1);

            var entity = result.entities.First();
            entity.OriginalValue.Should().Be(10);
            entity.RuleId.Should().Be(rule.Id);
            entity.CorrectedValue.Should().Be(10.24m);
            entity.NumberOfDaysLate.Should().Be(2);
        }

        [Fact]
        public void AccountApplicationService_Add_when_not_exist_rule()
        {
            var model = new AccountModel
            {
                OriginalValue = 10,
                PaymentDate = DateTime.Now.Date,
                DueDate = DateTime.Now.AddDays(-2).Date,
                Name = "test"
            };

            _accountApplicationService.Add(model);

            var result = _accountRepository.Get(new Filter());

            result.entities.Should().HaveCount(1);

            var entity = result.entities.First();
            entity.OriginalValue.Should().Be(10);
            entity.RuleId.Should().BeNull();
            entity.CorrectedValue.Should().Be(10);
            entity.NumberOfDaysLate.Should().Be(2);
        }

        [Fact]
        public void AccountApplicationService_Add_when_payment_was_the_same_day()
        {
            var model = new AccountModel
            {
                OriginalValue = 10,
                PaymentDate = DateTime.Now.Date,
                DueDate = DateTime.Now.Date,
                Name = "test"
            };

            var rule = new RuleBuilder().WithDays(3).WithType(RuleType.UpUntil).WithPenalty(2).WithInterestPerDay(0.2m).Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _accountApplicationService.Add(model);

            var result = _accountRepository.Get(new Filter());

            result.entities.Should().HaveCount(1);

            var entity = result.entities.First();
            entity.OriginalValue.Should().Be(10);
            entity.RuleId.Should().BeNull();
            entity.CorrectedValue.Should().Be(10);
            entity.NumberOfDaysLate.Should().Be(0);
        }

        [Fact]
        public void AccountApplicationService_Add_when_dont_get_the_rule()
        {
            var model = new AccountModel
            {
                OriginalValue = 10,
                PaymentDate = DateTime.Now.Date,
                DueDate = DateTime.Now.AddDays(-2).Date,
                Name = "test"
            };

            var rule = new RuleBuilder().WithDays(3).WithType(RuleType.After).WithPenalty(2).WithInterestPerDay(0.2m).Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _accountApplicationService.Add(model);

            var result = _accountRepository.Get(new Filter());

            result.entities.Should().HaveCount(1);

            var entity = result.entities.First();
            entity.OriginalValue.Should().Be(10);
            entity.RuleId.Should().BeNull();
            entity.CorrectedValue.Should().Be(10.0m);
            entity.NumberOfDaysLate.Should().Be(2);
        }

        [Fact]
        public void AccountApplicationService_Remove()
        {
            var rule = new RuleBuilder().WithDays(3).WithType(RuleType.UpUntil).WithPenalty(2).WithInterestPerDay(0.2m).Builder();
            var account = new AccountBuilder().WithRule(rule).Builder();

            _ruleRepository.Add(rule);
            _accountRepository.Add(account);
            _unitOfWork.Commit();

            _accountApplicationService.Remove(account.Id);

            var result = _accountRepository.Get(new Filter());

            result.entities.Should().HaveCount(0);
        }
    }
}
