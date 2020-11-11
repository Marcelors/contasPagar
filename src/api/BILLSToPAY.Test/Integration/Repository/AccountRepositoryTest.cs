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
    public class AccountRepositoryTest : TestIntegrationBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountRepositoryTest() : base()
        {
            _accountRepository = GetInstance<IAccountRepository>();
            _ruleRepository = GetInstance<IRuleRepository>();
            _unitOfWork = GetInstance<IUnitOfWork>();
        }

        [Fact]
        public void AccountRepository_Get()
        {
            var rule = new RuleBuilder().Builder();
            var account_1 = new AccountBuilder().WithName("conta do banco").Builder();
            var account_2 = new AccountBuilder().WithName("conta do cartao").Builder();
            var account_3 = new AccountBuilder().WithName("conta da casa").Builder();

            _ruleRepository.Add(rule);
            _accountRepository.Add(account_1);
            _accountRepository.Add(account_2);
            _accountRepository.Add(account_3);
            _unitOfWork.Commit();

            var filter = new Filter();

            var result = _accountRepository.Get(filter);

            result.totalItems.Should().Be(3);
            result.entities.Should().HaveCount(3);

            filter.Search = "conta do banco";
            result = _accountRepository.Get(filter);

            result.totalItems.Should().Be(1);
            result.entities.Should().HaveCount(1);
            result.entities.First().Should().Be(account_1);

            filter.Search = string.Empty;
            filter.CurrentPage = 1;
            filter.ItemsPerPage = 2;

            result = _accountRepository.Get(filter);

            result.totalItems.Should().Be(3);
            result.entities.Should().HaveCount(2);
        }
    }
}
