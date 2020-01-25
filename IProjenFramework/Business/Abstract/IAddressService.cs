using Core.Utilities.Results;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<Country>> GetCountries();
        List<City> GetCities(int countryId);
        List<District> GetDistricts(int cityId);
    }
}
