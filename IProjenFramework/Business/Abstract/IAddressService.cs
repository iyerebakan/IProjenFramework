using Core.Utilities.Results;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        Task<IDataResult<List<Country>>> GetCountries();
        Task<List<City>> GetCities(int countryId);
        Task<List<District>> GetDistricts(int cityId);
    }
}
