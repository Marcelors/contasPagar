using System.ComponentModel.DataAnnotations;
using BILLSToPAY.Domain.Shared.Resources;

namespace BILLSToPAY.Domain.Shared.Enums
{
    public enum RuleType : short
    {
        [Display(Name = nameof(Resource.UpUntil), ResourceType = typeof(Resource))]
        UpUntil = 1,
        [Display(Name = nameof(Resource.After), ResourceType = typeof(Resource))]
        After = 2
    }
}
