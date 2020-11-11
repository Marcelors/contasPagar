using System;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Domain.Validation;

namespace BILLSToPAY.Domain.DTO
{
    public class AccountDto : BaseDto
    {
        public string Name { get; set; }
        public decimal? OriginalValue { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }

        public bool IsValid()
        {
            var validation = new AccountValidation();
            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
