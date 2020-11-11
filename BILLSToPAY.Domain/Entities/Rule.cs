using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.Domain.Entities
{
    public class Rule : Entity
    {
        public Rule(int days, RuleType type, decimal interestPerDay, decimal penalty)
        {
            Days = days;
            Type = type;
            InterestPerDay = interestPerDay;
            Penalty = penalty;
            Active = true;
        }

        public int Days { get; protected set; }
        public RuleType Type { get; protected set; }
        public decimal InterestPerDay { get; protected set; }
        public decimal Penalty { get; protected set; }
        public bool Active { get; protected set; }

        public void Enable()
        {
            Active = true;
        }

        public void Disable()
        {
            Active = false;
        }
    }
}
