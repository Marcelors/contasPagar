using System;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Shared.Extensions;

namespace BILLSToPAY.Test.Builder
{
    public class AccountBuilder
    {
        private string _name;
        private decimal? _originalValue;
        private DateTime? _paymentDate;
        private DateTime? _dueDate;
        private decimal? _correctedValue;
        private int? _numberOfDaysLate;
        private Rule _rule;

        public Account Builder()
        {
            var account = new Account(name: _name.HasValue() ? _name : "test",
                originalValue: _originalValue.HasValue ? _originalValue.Value : 1,
                paymentDate: _paymentDate.HasValue ? _paymentDate.Value : DateTime.Now.Date,
                dueDate: _dueDate.HasValue ? _dueDate.Value : DateTime.Now.Date,
                correctedValue: _correctedValue.HasValue ? _correctedValue.Value : 1,
                numberOfDaysLate: _numberOfDaysLate.HasValue ? _numberOfDaysLate.Value : 0,
                rule: _rule == null ? new RuleBuilder().Builder() : _rule);

            account.WithId();

            return account;
        }

        public AccountBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }

        public AccountBuilder WithNumberOfDaysLate(int numberOfDaysLate)
        {
            _numberOfDaysLate = numberOfDaysLate;
            return this;
        }

        public AccountBuilder WithCorrectedValue(decimal correctedValue)
        {
            _correctedValue = correctedValue;
            return this;
        }

        public AccountBuilder WithDueDate(DateTime dueDate)
        {
            _dueDate = dueDate;
            return this;
        }

        public AccountBuilder WithPaymentDate(DateTime paymentDate)
        {
            _paymentDate = paymentDate;
            return this;
        }

        public AccountBuilder WithOriginalValue(decimal originalValue)
        {
            _originalValue = originalValue;
            return this;
        }

        public AccountBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
