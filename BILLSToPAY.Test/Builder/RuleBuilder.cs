using System;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Shared.Enums;

namespace BILLSToPAY.Test.Builder
{
    public class RuleBuilder
    {
        private int? _days;
        public RuleType? _type;
        public decimal? _interestPerDay;
        public decimal? _penalty;
        public bool? _active;

        public Rule Builder()
        {
            var rule = new Rule(days: _days.HasValue ? _days.Value : 1,
                type: _type.HasValue ? _type.Value : RuleType.UpUntil,
                interestPerDay: _interestPerDay.HasValue ? _interestPerDay.Value : 2,
                penalty: _penalty.HasValue ? _penalty.Value : 0.1m);

            rule.WithId();

            if (_active.HasValue)
            {
                if (_active.Value)
                {
                    rule.Enable();
                } else
                {
                    rule.Disable();
                }
            }

            return rule;
        }

        public RuleBuilder WithDays(int days)
        {
            _days = days;
            return this;
        }

        public RuleBuilder WithType(RuleType type)
        {
            _type = type;
            return this;
        }

        public RuleBuilder WithInterestPerDay(int interestPerDay)
        {
            _interestPerDay = interestPerDay;
            return this;
        }

        public RuleBuilder WithPenalty(int penalty)
        {
            _penalty = penalty;
            return this;
        }

        public RuleBuilder Enable()
        {
            _active = true;
            return this;
        }

        public RuleBuilder Disable()
        {
            _active = false;
            return this;
        }
    }
}
