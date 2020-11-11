using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Shared.Extensions;
using BILLSToPAY.Domain.Shared.Parameters;
using BILLSToPAY.Domain.Shared.Resources;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Units
{
    public class AccountDtoTest
    {
        [Theory]
        [ClassData(typeof(AccountDataTest))]
        public void AccountDto_is_not_valid(AccountDto dto, string message)
        {
            var result = dto.IsValid();

            result.Should().BeFalse();
            dto.ValidationResult.Errors.Should().NotBeNullOrEmpty();
            dto.ValidationResult.Errors.First().ErrorMessage.Should().Be(message);
        }

        [Fact]
        public void AccountDto_is_valid()
        {
            var dto = new AccountDto
            {
                Name = "test",
                DueDate = DateTime.Now,
                PaymentDate = DateTime.Now,
                OriginalValue = 10
            };

            var result = dto.IsValid();

            result.Should().BeTrue();

            dto.ValidationResult.Errors.Should().BeNullOrEmpty();
        }
    }

    public class AccountDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Name
            yield return new object[]
            {
                new AccountDto
                {
                    Name = null,
                    DueDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    OriginalValue = 10
                },
                DomainError.NameIsRequired
            };
            yield return new object[]
            {
                new AccountDto
                {
                    Name = "",
                    DueDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    OriginalValue = 10
                },
                DomainError.NameIsRequired
            };
            yield return new object[]
            {
                new AccountDto
                {
                    Name = StringExtension.GenerateString(DomainParameters.MaxLenghtOfTwoHundred + 1),
                    DueDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    OriginalValue = 10
                },
                string.Format(DomainError.MaximumNameSize, DomainParameters.MaxLenghtOfTwoHundred)
            };
            //DueDate
            yield return new object[]
            {
                new AccountDto
                {
                    Name = "test",
                    DueDate = null,
                    PaymentDate = DateTime.Now,
                    OriginalValue = 10
                },
                DomainError.DueDateIsRequired
            };
            //PaymentDate
            yield return new object[]
            {
                new AccountDto
                {
                    Name = "test",
                    DueDate = DateTime.Now,
                    PaymentDate = null,
                    OriginalValue = 10
                },
                DomainError.PaymentDateIsRequired
            };
            //OriginalValue
            yield return new object[]
            {
                new AccountDto
                {
                    Name = "test",
                    DueDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    OriginalValue = null
                },
                DomainError.OriginalValueIsRequired
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
