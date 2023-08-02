using CityAPI.Core;

namespace CityAPI.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(UserEntity user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
