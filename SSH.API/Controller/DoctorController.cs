﻿using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Recipe.Common.Helper;
using Recipe.Core.Base.Generic;
using SSH.API.Infrastructure;
using SSH.Core.Attribute;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.IService;

namespace SSH.API.Controller
{
    [CustomAuthorize]
    [RoutePrefix("Doctor")]
    public class DoctorController : Controller<IDoctorService, DoctorDTO, Doctor, int>
    {
        public DoctorController(IDoctorService service)
            : base(service)
        {
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ResponseMessageResult> GetAll()
        {
            var request = Request.GetJsonApiRequest();
            var result = await this.Service.GetAllAsync(request);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpGet]
        [Route("GetSingle")]
        public async Task<ResponseMessageResult> GetSingle(int id)
        {
            var result = await this.Service.GetAsync(id);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ResponseMessageResult> CreateDoctor(DoctorDTO dtoObject)
        {
            var result = await this.Service.CreateAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ResponseMessageResult> UpdateDoctor(DoctorDTO dtoObject)
        {
            var result = await this.Service.UpdateAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ResponseMessageResult> DeleteDoctor(int id)
        {
            await this.Service.DeleteAsync(id);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, id);
        }
    }
}