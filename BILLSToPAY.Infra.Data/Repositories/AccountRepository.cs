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
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(BillToPayContext context) : base(context)
        {
        }

        public override (int totalItems, IList<Account> entities) Get(Filter filter)
        {
            var query = GetAll();
            var totalItems = 0;

            if (filter.Search.HasValue())
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(filter.Search.ToLower()));
            }

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
    }
}
