using System;
using System.Linq;
using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Domain.Shared.Resources;
using BILLSToPAY.Test.Builder;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Integration.ApplicationService
{
    public class RuleApplicationServiceTest : TestIntegrationBase
    {
        private readonly IRuleApplicationService _ruleApplicationService;
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RuleApplicationServiceTest() : base()
        {
            CreateScope();

            _ruleApplicationService = GetIntanceScope<IRuleApplicationService>();
            _ruleRepository = GetIntanceScope<IRuleRepository>();
            _unitOfWork = GetIntanceScope<IUnitOfWork>();
        }

        [Fact]
        public void RuleApplicationService_Add()
        {
            var model = new RuleModel()
            {
                Days = 1,
                InterestPerDay = 0.2m,
                Penalty = 2,
                Type = (short)RuleType.After
            };

            _ruleApplicationService.Add(model);

            var result = _ruleRepository.Get(new Filter());

            result.entities.Should().HaveCount(1);
            var entity = result.entities.First();

            entity.Days.Should().Be(model.Days);
            entity.InterestPerDay.Should().Be(model.InterestPerDay);
            entity.Penalty.Should().Be(model.Penalty);
            entity.Type.Should().Be((RuleType)model.Type);
        }

        [Fact]
        public void RuleApplicationService_Remove()
        {
            var rule = new RuleBuilder().Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _ruleApplicationService.Remove(rule.Id);

            var result = _ruleRepository.Get(new Filter());

            result.entities.Should().HaveCount(0);
        }

        [Fact]
        public void RuleApplicationService_Enable()
        {
            var rule = new RuleBuilder().Disable().Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _ruleApplicationService.Enable(rule.Id);

            var entity = _ruleRepository.GetById(rule.Id);
            entity.Active.Should().BeTrue();
        }

        [Fact]
        public void RuleApplicationService_Enable_when_the_item_not_found()
        {
            var rule = new RuleBuilder().Disable().Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _ruleApplicationService.Enable(Guid.NewGuid());

            DomainNotificationHandler.HasNotifications().Should().BeTrue();
            DomainNotificationHandler.GetNotifications.First().Value.Should().Be(DomainError.RuleNotFound);

            var entity = _ruleRepository.GetById(rule.Id);
            entity.Active.Should().BeFalse();
        }

        [Fact]
        public void RuleApplicationService_Disable()
        {
            var rule = new RuleBuilder().Enable().Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _ruleApplicationService.Disable(rule.Id);

            var entity = _ruleRepository.GetById(rule.Id);
            entity.Active.Should().BeFalse();
        }

        [Fact]
        public void RuleApplicationService_Disable_when_the_item_not_found()
        {
            var rule = new RuleBuilder().Enable().Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            _ruleApplicationService.Disable(Guid.NewGuid());

            DomainNotificationHandler.HasNotifications().Should().BeTrue();
            DomainNotificationHandler.GetNotifications.First().Value.Should().Be(DomainError.RuleNotFound);

            var entity = _ruleRepository.GetById(rule.Id);
            entity.Active.Should().BeTrue();
        }
    }
}
