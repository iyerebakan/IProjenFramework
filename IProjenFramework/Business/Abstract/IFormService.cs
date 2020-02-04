using Core.Utilities.Results;
using Entities.Entities.EntityForm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFormService
    {
        Task<IDataResult<List<Form>>> GetForms();
        Task<IDataResult<List<DesignGroup>>> GetDesignGroups();
        Task<IDataResult<List<DesignGroupDetail>>> GetDesignGroupDetails();
    }
}
