using Core.Utilities.Results;
using Entities.Entities.EntityForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFormService
    {
        IDataResult<List<Form>> GetForms();
        IDataResult<List<DesignGroup>> GetDesignGroups();
        IDataResult<List<DesignGroupDetail>> GetDesignGroupDetails();
    }
}
