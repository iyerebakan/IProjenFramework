using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
using Entities.Entities.EntityForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FormManager : IFormService
    {
        private readonly RepositoryDesignGroup _repositoryDesignGroup;
        private readonly RepositoryDesignGroupDetail _repositoryDesignGroupDetail;
        private readonly RepositoryForm _repositoryForm;

        public FormManager(
            RepositoryForm repositoryForm,
            RepositoryDesignGroupDetail repositoryDesignGroupDetail,
            RepositoryDesignGroup repositoryDesignGroup)
        {
            _repositoryDesignGroup = repositoryDesignGroup;
            _repositoryDesignGroupDetail = repositoryDesignGroupDetail;
            _repositoryForm = repositoryForm;
        }

        public IDataResult<List<DesignGroupDetail>> GetDesignGroupDetails()
        {
            try
            {
                return new SuccessDataResult<List<DesignGroupDetail>>
                    (_repositoryDesignGroupDetail.GetAll());
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
                    (_repositoryDesignGroup.GetAll());
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
                    (_repositoryForm.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Form>>
                    ("Bir Hata Oluştu..!" + ex.Message);
            }
        }
    }
}
