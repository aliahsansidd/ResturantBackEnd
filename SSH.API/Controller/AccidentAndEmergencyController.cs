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
    [RoutePrefix("AccidentAndEmergency")]
    public class AccidentAndEmergencyController : Controller<IAccidentAndEmergencyService, AccidentAndEmergencyDTO, AccidentAndEmergency, int>
    {
        public AccidentAndEmergencyController(IAccidentAndEmergencyService service)
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
        public async Task<ResponseMessageResult> CreateAccidentAndEmergency(AccidentAndEmergencyDTO dtoObject)
        {
            var result = await this.Service.CreateAsync(dtoObject);
           //// dtoObject.BroughterDetails.ForEach(u => { u.AccidentAndEmergencyID = result.Id; });
            //// var result2 = await 
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.NoContent, null);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ResponseMessageResult> UpdateAccidentAndEmergency(AccidentAndEmergencyDTO dtoObject)
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
        public async Task<ResponseMessageResult> DeleteBed(int id)
        {
            await this.Service.DeleteAsync(id);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, id);
        }
    }
}