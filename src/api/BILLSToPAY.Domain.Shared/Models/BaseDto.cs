using FluentValidation.Results;

namespace BILLSToPAY.Domain.Shared.Models
{
    public class BaseDto
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
