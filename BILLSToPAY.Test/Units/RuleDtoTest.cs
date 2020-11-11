using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Resources;
using FluentAssertions;
using Xunit;

namespace BILLSToPAY.Test.Units
{
    public class RuleDtoTest
    {
        [Theory]
        [ClassData(typeof(RuleDataTest))]
        public void RuleDto_is_not_valid(RuleDto dto, string message)
        {
            var result = dto.IsValid();

            result.Should().BeFalse();
            dto.ValidationResult.Errors.Should().NotBeNullOrEmpty();
            dto.ValidationResult.Errors.First().ErrorMessage.Should().Be(message);
        }

        [Fact]
        public void RuleDto_is_valid()
        {
            var dto = new RuleDto
            {
                Days = 1,
                InterestPerDay = 0.2m,
                Penalty = 2,
                Type = RuleType.UpUntil
            };

            var result = dto.IsValid();

            result.Should().BeTrue();

            dto.ValidationResult.Errors.Should().BeNullOrEmpty();
        }
    }

    public class RuleDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //Days
            yield return new object[]
            {
               new RuleDto
               {
                    Days = null,
                    InterestPerDay = 0.2m,
                    Penalty = 2,
                    Type = RuleType.UpUntil
               },
               DomainError.DaysIsRequired
            };
            //InterestPerDay
            yield return new object[]
            {
               new RuleDto
               {
                    Days = 1,
                    InterestPerDay = null,
                    Penalty = 2,
                    Type = RuleType.UpUntil
               },
               DomainError.InterestPerDayIsRequired
            };
            //Penalty
            yield return new object[]
            {
               new RuleDto
               {
                    Days = 1,
                    InterestPerDay = 0.2m,
                    Penalty = null,
                    Type = RuleType.UpUntil
               },
               DomainError.PenaltyIsRequired
            };
            //Type
            yield return new object[]
            {
               new RuleDto
               {
                    Days = 1,
                    InterestPerDay = 0.2m,
                    Penalty = 2,
                    Type = null
               },
               DomainError.TypeIsRequired
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
