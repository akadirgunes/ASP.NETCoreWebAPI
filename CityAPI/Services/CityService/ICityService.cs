using CityAPI.Core;
using CityAPI.Core.Dtos.City;

namespace CityAPI.Services.CityService
{
    public interface ICityService
    {
        Task<ServiceResponse<List<GetCity>>> GetAllCity();
        Task<ServiceResponse<GetCity>> GetAllCityById(int id);
        Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newcity);
        Task<ServiceResponse<GetCity>> UpdateCity(UpdateCity updateCity);
        Task<ServiceResponse<List<GetCity>>> DeleteCity(int id);
    }
}
