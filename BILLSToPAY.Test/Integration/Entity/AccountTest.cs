using System;
using BILLSToPAY.Domain.Interfaces;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Test.Builder;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Integration.Entity
{
    public class AccountTest : TestIntegrationBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountTest() : base()
        {
            _accountRepository = GetInstance<IAccountRepository>();
            _ruleRepository = GetInstance<IRuleRepository>();
            _unitOfWork = GetInstance<IUnitOfWork>();
        }

        [Fact]
        public void Account_test()
        {
            var rule = new RuleBuilder().Builder();
            var account = new AccountBuilder().WithRule(rule).Builder();

            _ruleRepository.Add(rule);
            _accountRepository.Add(account);
            _unitOfWork.Commit();

            var result = _accountRepository.GetById(account.Id);

            result.Should().NotBeNull();
            result.Should().Be(account);
        }
    }
}
