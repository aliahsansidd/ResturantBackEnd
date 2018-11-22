using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Entity;

namespace SSH.Core.IRepository
{
    public interface ILabTestInventoryAllocationRepository : IRepository<LabTestInventoryAllocation, int>
    {
    }
}
