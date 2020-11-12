using System;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.ApplicationService.Model
{
    public class RuleModel
    {
        public Guid? Id { get; set; }
        public int? Days { get; set; }
        public short? Type { get; set; }
        public decimal? InterestPerDay { get; set; }
        public decimal? Penalty { get; set; }
        public EnumModel<short> TypeModel { get; set; }
        public bool Active { get; set; }
    }
}
