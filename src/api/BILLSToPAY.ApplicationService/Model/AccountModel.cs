using System;
namespace BILLSToPAY.ApplicationService.Model
{
    public class AccountModel
    {
        public Guid? Id { get; set; }
        public string Name { get;  set; }
        public decimal? OriginalValue { get;  set; }
        public DateTime? PaymentDate { get;  set; }
        public DateTime? DueDate { get;  set; }
        public decimal? CorrectedValue { get;  set; }
        public int? NumberOfDaysLate { get;  set; }
        public RuleModel Rule { get; set; }
    }
}
