using BILLSToPAY.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BILLSToPAY.Infra.Data.Mappings
{
    public class RuleMapping : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.Property(x => x.Days).IsRequired();
            builder.Property(x => x.InterestPerDay).HasColumnType("decimal(18, 6)").IsRequired();
            builder.Property(x => x.Penalty).HasColumnType("decimal(18, 6)").IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
