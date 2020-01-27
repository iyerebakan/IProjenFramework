using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete;
using Entities.Entities.EntityForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FormManager : IFormService
    {
        public IDataResult<List<DesignGroupDetail>> GetDesignGroupDetails()
        {
            try
            {
                return new SuccessDataResult<List<DesignGroupDetail>>
                    (Repositories.RepositoryDesignGroupDetail.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<DesignGroupDetail>>
                    ("Bir Hata Oluştu..!" + ex.Message);
            }
        }

        public IDataResult<List<DesignGroup>> GetDesignGroups()
        {
            try
            {
                return new SuccessDataResult<List<DesignGroup>>
                    (Repositories.RepositoryDesignGroup.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<DesignGroup>>
                    ("Bir Hata Oluştu..!" + ex.Message);
            }
        }

        public IDataResult<List<Form>> GetForms()
        {
            try
            {
                return new SuccessDataResult<List<Form>>
                    (Repositories.RepositoryForm.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Form>>
                    ("Bir Hata Oluştu..!" + ex.Message);
            }
        }
    }
}
