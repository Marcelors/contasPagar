using System;
using System.Collections.Generic;
using System.Linq;
using BILLSToPAY.Domain.Entities;
using BILLSToPAY.Domain.Interfaces.Repositories;
using BILLSToPAY.Domain.Shared.Extensions;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Infra.Data.Context;

namespace BILLSToPAY.Infra.Data.Repositories
{
    public class RuleRepository : RepositoryBase<Rule>, IRuleRepository
    {
        public RuleRepository(BillToPayContext context) : base(context)
        {
        }

        public override (int totalItems, IList<Rule> entities) Get(Filter filter)
        {
            var query = GetAll();
            var totalItems = 0;

            if (filter.TotalItems.HasValue)
            {
                totalItems = filter.TotalItems.Value;
            }
            else
            {
                totalItems = query.Count();
            }

            query = query.Paginate(filter.CurrentPage, filter.ItemsPerPage);

            var entities = query.ToList();

            return (totalItems: totalItems, entities: entities);
        }

        public IList<Rule> GetActives()
        {
            return GetAll().Where(x => x.Active).ToList();
        }
    }
}
