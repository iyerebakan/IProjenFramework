using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityRepositories;
using EntityCustomer.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IDataResult<List<Country>>> GetCountries()
        {
            try
            {
                return new SuccessDataResult<List<Country>>
                    (await _repositoryCountry.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Country>>(ex.Message);
            }
        }

        public async Task<List<City>> GetCities(int countryId)
        {
            return await _repositoryCity.GetAll(k => k.CountryId == countryId);
        }
        
        public async Task<List<District>> GetDistricts(int cityId)
        {
            return await _repositoryDistrict.GetAll(k => k.CityId == cityId);
        }
    }
}
