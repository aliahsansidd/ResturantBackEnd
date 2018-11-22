using System.Threading.Tasks;
using Recipe.Core.Base.Interface;
using SSH.Core.Entity;

namespace SSH.Core.IRepository
{
    public interface IRoleRepository : IRepository<ApplicationRole, string>
    {
        //Task<IEnumerable<ApplicationRole>> GetAll();

        Task<ApplicationRole> GetByName(string name);
    }
}
