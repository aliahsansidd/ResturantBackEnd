using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Attribute;
using Recipe.Core.Base.Interface;
using Recipe.Core.Enum;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.IRepository;

namespace SSH.Core.IService
{
    public interface ILabTestTemplateService : IService<ILabTestTemplateRepository, LabTestTemplate, LabTestTemplateDTO, int>
    {
    }
}
