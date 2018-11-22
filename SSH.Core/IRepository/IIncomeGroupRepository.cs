using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Common.Helper;
using Recipe.Core.Base.Interface;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.IRepository
{
    public interface IIncomeGroupRepository : IRepository<IncomeGroup, int>
    {
    }
}
