using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Recipe.Common.Helper;
using SSH.API.Infrastructure;
using SSH.Common.Attribute;
using SSH.Core.Attribute;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Helper;
using SSH.Core.IService;

namespace SSH.API.Controller
{
    [CustomAuthorize]
    [RoutePrefix("LOV")]
    public class LOVController : Recipe.Core.Base.Generic.Controller<ILOVService, LOVDTO, LOV, int>
    {
        private ILOVService lovService;

        public LOVController(ILOVService lovService)
            : base(lovService)
        {
            this.lovService = lovService;
        }
        
        [HttpPut]
        [Route("Update")]
        public async Task<ResponseMessageResult> Update(List<LOVDTO> dtoObject)
        {
            var result = await this.lovService.UpdateAsync(dtoObject);
            if (result != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
            }

            return await this.JsonApiNoContentAsync(Message.DataUpdateFailed, null);
        }
        
        [HttpGet]
        [Route("Get")]
        public async Task<ResponseMessageResult> GetAll()
        {
            var request = Request.GetJsonApiRequest();
            var result = await this.lovService.GetUpdatedListAsync(request);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
        }
        
        [HttpGet]
        [Route("GetAllGroups")]
        public async Task<ResponseMessageResult> GetAllGroups()
        {
            var result = await this.lovService.GetAllGroups();
            return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
        }

        [HttpGet]
        [Route("GetByGroup")]
        public async Task<ResponseMessageResult> GetByGroup(string groupName)
        {
            var result = await this.lovService.GetByGroup(groupName);
            return await this.JsonApiSuccessAsync(Message.SuccessResult, result);
        }

        [HttpGet]
        [Route("GetSingle")]
        public async Task<ResponseMessageResult> GetSignle(int id)
        {
            var lov = await this.Service.GetAsync(id);
            if (lov != null)
            {
                return await this.JsonApiSuccessAsync(Message.SuccessResult, lov);
            }

            return await this.JsonApiNotFoundAsync(string.Format(Message.NotFound, "LOV"), null);
        }
    }
}
