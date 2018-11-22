using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Extensions;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;
using SSH.Core.IService;

namespace SSH.Service
{
    public class BedAllocationService : Service<IBedAllocationRepository, BedAllocation, BedAllocationDTO, int>, IBedAllocationService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public BedAllocationService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.BedAllocationRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<BedAllocationDTO> CreateAsync(BedAllocationDTO dtoObject)
        {
            var result = await base.CreateAsync(dtoObject);
            if (result == null)
            {
                this.exceptionHelper.ThrowAPIException(string.Format(Message.Error, dtoObject));
            }

            //  var bed = setBedStatus(result.BedId, (int)BedStatus.Occupied);

            // Update last allocation status of bed 
            var entity = await this.unitOfWork.BedRepository.GetAsync(result.BedId);

            entity.Status = (int)BedStatus.Occupied;
            entity.LastModifiedBy = this.requestInfo.UserId;
            entity.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<Bed>().Attach(entity);
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.Status).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedBy).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedOn).IsModified = true;
            await this.UnitOfWork.SaveAsync();

            return result;
        }

        public async Task<BedAllocationDTO> TransferBed(BedAllocationDTO bedAllocationDTO)
        {
            var bedAllocation = await this.GetAsync(bedAllocationDTO.Id);
            // Transfer bed to patient
            //bedAllocation.ReferenceNumber = bedAllocation.BedId.ToString();
            var transferBed = await this.CreateAsync(bedAllocationDTO);

            var entity = await this.unitOfWork.BedRepository.GetAsync(bedAllocation.BedId);

            entity.Status = (int)BedStatus.Available;
            entity.LastModifiedBy = this.requestInfo.UserId;
            entity.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<Bed>().Attach(entity);
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.Status).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedBy).IsModified = true;
            this.UnitOfWork.DBContext.Entry(entity).Property(x => x.LastModifiedOn).IsModified = true;

            var allocationStatus = await this.Repository.GetAsync(bedAllocation.Id);

            allocationStatus.Status = (int)BedAllocationStatus.Transferred;
            allocationStatus.ReferenceNumber = transferBed.BedId.ToString();
            allocationStatus.TransferDateTime = DateTime.UtcNow;
            allocationStatus.LastModifiedBy = this.requestInfo.UserId;
            allocationStatus.LastModifiedOn = DateTime.UtcNow;

            this.UnitOfWork.DBContext.Set<BedAllocation>().Attach(allocationStatus);
            this.UnitOfWork.DBContext.Entry(allocationStatus).Property(x => x.Status).IsModified = true;
            this.UnitOfWork.DBContext.Entry(allocationStatus).Property(x => x.ReferenceNumber).IsModified = true;
            this.UnitOfWork.DBContext.Entry(allocationStatus).Property(x => x.TransferDateTime).IsModified = true;
            this.UnitOfWork.DBContext.Entry(allocationStatus).Property(x => x.LastModifiedBy).IsModified = true;
            this.UnitOfWork.DBContext.Entry(allocationStatus).Property(x => x.LastModifiedOn).IsModified = true;

            await this.UnitOfWork.SaveAsync();
            return transferBed;
        }

        //public async Task<bool> setBedStatus(int bedID,int status)
        //{

        //    return true;
        //}
    }
}
