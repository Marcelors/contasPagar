using System;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Test.Builder;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Integration.Entity
{
    public class RuleTest : TestIntegrationBase
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RuleTest() : base()
        {
            _ruleRepository = GetInstance<IRuleRepository>();
            _unitOfWork = GetInstance<IUnitOfWork>();
        }

        [Fact]
        public void Rule_test()
        {
            var rule = new RuleBuilder().Builder();

            _ruleRepository.Add(rule);
            _unitOfWork.Commit();

            var result = _ruleRepository.GetById(rule.Id);

            result.Should().NotBeNull();
            result.Should().Be(rule);
        }
    }
}
