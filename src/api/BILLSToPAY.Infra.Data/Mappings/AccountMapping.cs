using System;
using BILLSToPAY.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BILLSToPAY.Infra.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.OriginalValue).HasColumnType("decimal(18, 6)").IsRequired();
            builder.Property(x => x.CorrectedValue).HasColumnType("decimal(18, 6)").IsRequired();
            builder.Property(x => x.DueDate).IsRequired();
            builder.Property(x => x.NumberOfDaysLate).IsRequired();
            builder.Property(x => x.PaymentDate).IsRequired();

            builder.HasOne(x => x.Rule).WithMany().HasForeignKey(x => x.RuleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
