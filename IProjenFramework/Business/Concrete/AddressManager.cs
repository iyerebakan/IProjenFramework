using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        public IDataResult<List<Country>> GetCountries()
        {
            try
            {
                return new SuccessDataResult<List<Country>>
                    (Repositories.RepositoryCountry.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Country>>(ex.Message);
            }
        }

        public List<City> GetCities(int countryId)
        {
            return Repositories.RepositoryCity.GetAll(k => k.CountryId == countryId);
        }
        
        public List<District> GetDistricts(int cityId)
        {
            return Repositories.RepositoryDistrict.GetAll(k => k.CityId == cityId);
        }
    }
}
