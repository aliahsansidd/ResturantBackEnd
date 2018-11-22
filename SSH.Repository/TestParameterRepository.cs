using Recipe.Core.Base.Generic;
using SSH.Core.Entity;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class TestParameterRepository : AuditableRepository<TestParameter, int>, ITestParameterRepository
    {
        private ISSHRequestInfo requestInfo;

        public TestParameterRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }
    }
}
