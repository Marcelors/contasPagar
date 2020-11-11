using System;
using BILLSToPAY.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BILLSToPAY.Infra.Data.Context
{
    public class BillToPayContext : DbContext
    {
        public BillToPayContext()
        {
        }

        public BillToPayContext(DbContextOptions<BillToPayContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RuleMapping());
            modelBuilder.ApplyConfiguration(new AccountMapping());
        }
    }
}
