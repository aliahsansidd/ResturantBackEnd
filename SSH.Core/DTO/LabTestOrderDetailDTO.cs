using System;
using Recipe.Core.Base.Abstract;
using SSH.Core.Entity;
using SSH.Core.Enum;

namespace SSH.Core.DTO
{
    public class LabTestOrderDetailDTO : DTO<LabTestOrderDetail, int>
    {
        public int LabTestOrderId { get; set; }

        public int LabTestBuilderId { get; set; }

        public DateTime? EndTime { get; set; }

        public string DoctorRemarks { get; set; }

        public string TestReportUrl { get; set; }

        public bool IsUrgent { get; set; }

        public bool IsOutSource { get; set; }

        public string OutSourceHospitalName { get; set; }

        public int? DoctorId { get; set; }

        public LabTestStatus TestStatus { get; set; }

        public double TestUnitPrice { get; set; }

        public LabTestPriorityStatus Priority { get; set; }

        public override void ConvertFromEntity(LabTestOrderDetail entity)
        {
            base.ConvertFromEntity(entity);
            this.LabTestBuilderId = entity.LabTestBuilderId;
            this.LabTestOrderId = entity.LabTestOrderId;
            this.DoctorRemarks = entity.DoctorRemarks;
            this.TestReportUrl = entity.TestReportUrl;
            this.IsUrgent = entity.IsUrgent;
            this.IsOutSource = entity.IsOutSource;
            this.OutSourceHospitalName = entity.OutSourceHospitalName;
            this.EndTime = (entity.EndTime == null) ? (DateTime?)null : Convert.ToDateTime(entity.EndTime).ToLocalTime();
            this.DoctorId = (this.DoctorId == null) ? (int?)null : this.DoctorId;
            this.TestUnitPrice = entity.TestUnitPrice;
            this.TestStatus = (LabTestStatus)entity.TestStatus;
            this.Priority = (LabTestPriorityStatus)entity.Priority;
        }

        public override LabTestOrderDetail ConvertToEntity(LabTestOrderDetail entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.LabTestBuilderId = this.LabTestBuilderId;
            entity.DoctorRemarks = this.DoctorRemarks;
            entity.TestReportUrl = null;
            entity.IsUrgent = this.IsUrgent;
            entity.IsOutSource = this.IsOutSource;
            entity.OutSourceHospitalName = this.OutSourceHospitalName;
            entity.EndTime = ((int)this.TestStatus == (int)LabTestStatus.Dispatch) ? DateTime.UtcNow : (DateTime?)null;
            entity.DoctorId = (this.DoctorId == 0 || this.DoctorId == null) ? null : this.DoctorId;
            entity.TestUnitPrice = this.TestUnitPrice;
            entity.TestStatus = (int)this.TestStatus;
            entity.Priority = (int)this.Priority;
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastModifiedOn = DateTime.UtcNow;

            return entity;
        }
    }
}