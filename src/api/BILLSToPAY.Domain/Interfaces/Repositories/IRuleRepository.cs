using System.Collections.Generic;
using BILLSToPAY.Domain.Entities;

namespace BILLSToPAY.Domain.Interfaces.Repositories
{
    public interface IRuleRepository : IRepositoryBase<Rule>
    {
        IList<Rule> GetActives();
    }
}
