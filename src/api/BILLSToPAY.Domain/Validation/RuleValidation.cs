using System;
using BILLSToPAY.Domain.DTO;
using BILLSToPAY.Domain.Shared.Resources;
using FluentValidation;

namespace BILLSToPAY.Domain.Validation
{
    public class RuleValidation : AbstractValidator<RuleDto>
    {
        public RuleValidation()
        {
            RuleFor(x => x.Days)
                .NotNull()
                .WithMessage(DomainError.DaysIsRequired);

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage(DomainError.TypeIsRequired);

            RuleFor(x => x.Penalty)
                .NotNull()
                .WithMessage(DomainError.PenaltyIsRequired);

            RuleFor(x => x.InterestPerDay)
                .NotNull()
                .WithMessage(DomainError.InterestPerDayIsRequired);
        }
    }
}
