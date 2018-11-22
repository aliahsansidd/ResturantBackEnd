using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.Common.Helper;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;

namespace SSH.Repository
{
    public class AppointmentRepository : AuditableRepository<Appointment, int>, IAppointmentRepository
    {
        private ISSHRequestInfo requestInfo;

        public AppointmentRepository(ISSHRequestInfo requestInfo)
            : base(requestInfo)
        {
            this.requestInfo = requestInfo;
        }

        protected override IQueryable<Appointment> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery.Where(x => x.IsDeleted == false)
                    .Include(x => x.DoctorOPDTimeSlot).Where(x => x.IsDeleted == false);
            }
        }

        protected override IQueryable<Appointment> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Where(x => x.IsDeleted == false)
                    .Include(x => x.DoctorOPDTimeSlot).Where(x => x.IsDeleted == false);
            }
        }

        public async Task<IEnumerable<Appointment>> GetByStatus(AppointmentStatus status)
        {
            return await this.DefaultListQuery.Where(x => x.Status == (int)status).ToListAsync();
        }
    }
}
