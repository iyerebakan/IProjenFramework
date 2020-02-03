using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly RepositoryCity _repositoryCity;
        private readonly RepositoryCountry _repositoryCountry;
        private readonly RepositoryDistrict _repositoryDistrict;

        public AddressManager(
            RepositoryCity repositoryCity, 
            RepositoryCountry repositoryCountry,
            RepositoryDistrict repositoryDistrict)
        {
            _repositoryCity = repositoryCity;
            _repositoryCountry = repositoryCountry;
            _repositoryDistrict = repositoryDistrict;
        }

        public IDataResult<List<Country>> GetCountries()
        {
            try
            {
                return new SuccessDataResult<List<Country>>
                    (_repositoryCountry.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Country>>(ex.Message);
            }
        }

        public List<City> GetCities(int countryId)
        {
            return _repositoryCity.GetAll(k => k.CountryId == countryId);
        }
        
        public List<District> GetDistricts(int cityId)
        {
            return _repositoryDistrict.GetAll(k => k.CityId == cityId);
        }
    }
}
