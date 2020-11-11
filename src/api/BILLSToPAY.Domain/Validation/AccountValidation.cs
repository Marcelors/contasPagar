using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Shared.Parameters;
using BILLSToPAY.Domain.Shared.Resources;
using FluentValidation;

namespace BILLSToPAY.Domain.Validation
{
    public class AccountValidation : AbstractValidator<AccountDto>
    {
        public AccountValidation()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage(DomainError.NameIsRequired)
                .NotEmpty()
                .WithMessage(DomainError.NameIsRequired)
                .MaximumLength(DomainParameters.MaxLenghtOfTwoHundred)
                .WithMessage(string.Format(DomainError.MaximumNameSize, DomainParameters.MaxLenghtOfTwoHundred));

            RuleFor(x => x.DueDate)
                .NotNull()
                .WithMessage(DomainError.DueDateIsRequired);

            RuleFor(x => x.OriginalValue)
                .NotNull()
                .WithMessage(DomainError.OriginalValueIsRequired);

            RuleFor(x => x.PaymentDate)
                .NotNull()
                .WithMessage(DomainError.PaymentDateIsRequired);
        }
    }
}
