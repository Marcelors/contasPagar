using System;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.Domain.Entities
{
    public class Account : Entity
    {
        public Account(string name, decimal originalValue, DateTime paymentDate, DateTime dueDate, decimal correctedValue, int numberOfDaysLate, Rule rule)
        {
            Name = name;
            OriginalValue = originalValue;
            PaymentDate = paymentDate;
            DueDate = dueDate;
            CorrectedValue = correctedValue;
            NumberOfDaysLate = numberOfDaysLate;
            Rule = rule;
            RuleId = rule == null ? (Guid?)null : rule.Id;
        }

        public string Name { get; protected set; }
        public decimal OriginalValue { get; protected set; }
        public DateTime PaymentDate { get; protected set; }
        public DateTime DueDate { get; protected set; }
        public decimal CorrectedValue { get; protected set; }
        public int NumberOfDaysLate { get; protected set; }
        public Rule Rule { get; protected set; }
        public Guid? RuleId { get; protected set; }

    }
}
