using BILLSToPAY.Domain.Shared.Enums;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Domain.Validation;

namespace BILLSToPAY.Domain.DTO
{
    public class RuleDto : BaseDto
    {
        public int? Days { get; set; }
        public RuleType? Type { get; set; }
        public decimal? InterestPerDay { get; set; }
        public decimal? Penalty { get; set; }

        public bool IsValid()
        {
            var validation = new RuleValidation();
            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
