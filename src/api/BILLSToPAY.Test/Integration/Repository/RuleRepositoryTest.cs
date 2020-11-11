using System;
using System.Linq;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Test.Builder;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Integration.Repository
{
    public class RuleRepositoryTest : TestIntegrationBase
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RuleRepositoryTest() : base()
        {
            _ruleRepository = GetInstance<IRuleRepository>();
            _unitOfWork = GetInstance<IUnitOfWork>();
        }

        [Fact]
        public void RuleRepository_Get()
        {
            var rule_1 = new RuleBuilder().Builder();
            var rule_2 = new RuleBuilder().Builder();
            var rule_3 = new RuleBuilder().Builder();

            _ruleRepository.Add(rule_1);
            _ruleRepository.Add(rule_2);
            _ruleRepository.Add(rule_3);

            _unitOfWork.Commit();

            var filter = new Filter();

            var result = _ruleRepository.Get(filter);

            result.totalItems.Should().Be(3);
            result.entities.Should().HaveCount(3);


            filter.Search = string.Empty;
            filter.CurrentPage = 1;
            filter.ItemsPerPage = 2;

            result = _ruleRepository.Get(filter);

            result.totalItems.Should().Be(3);
            result.entities.Should().HaveCount(2);
        }

        [Fact]
        public void RuleRepository_GetActives()
        {
            var rule_1 = new RuleBuilder().Disable().Builder();
            var rule_2 = new RuleBuilder().Builder();
            var rule_3 = new RuleBuilder().Disable().Builder();

            _ruleRepository.Add(rule_1);
            _ruleRepository.Add(rule_2);
            _ruleRepository.Add(rule_3);

            _unitOfWork.Commit();

            var result = _ruleRepository.GetActives();

            result.Should().HaveCount(1);
            result.First().Should().Be(rule_2);
        }
    }
}
