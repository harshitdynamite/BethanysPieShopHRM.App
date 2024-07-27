using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.App.Services
{
    public interface ICountryDataService
    {
        public Task<IEnumerable<Country>> GetAllCountries();
        public Task<Country> getCountrybyId(int countryId);
    }
}
