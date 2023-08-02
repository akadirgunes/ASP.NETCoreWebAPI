using AutoMapper;
using Azure;
using CityAPI.Core;
using CityAPI.Core.Dtos.City;
using CityAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;



namespace CityAPI.Services.CityService
{

    public class CityService : ICityService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CityService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<GetCity>>> AddCity(AddCity newcity)
        {
            var serviceResponse = new ServiceResponse<List<GetCity>>();
            CityEntity city = _mapper.Map<CityEntity>(newcity);
            city.User = await _context.userEntities.FirstOrDefaultAsync(x => x.Id == GetUserId());

            _context.CityEntities.Add(city);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.CityEntities
                .Where(x => x.User.Id == GetUserId())
                .Select(x => _mapper.Map<GetCity>(x)).ToListAsync();
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetCity>>> GetAllCity()
        {

            var response = new ServiceResponse<List<GetCity>>();

            var dbCityEnties = _context.CityEntities
                .Where(x => x.User.Id == GetUserId())
                .ToList();

            response.Data = dbCityEnties.Select(x => _mapper.Map<GetCity>(x)).ToList();
            return response;

        }

        public async Task<ServiceResponse<GetCity>> GetAllCityById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCity>();
            var dbcity = _context.CityEntities.FirstOrDefault(x => x.Id == id && x.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCity>(dbcity);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCity>> UpdateCity(UpdateCity updateCity)
        {
            ServiceResponse<GetCity> serviceresponse = new ServiceResponse<GetCity>();
            try
            {
                var city = await _context.CityEntities.FirstOrDefaultAsync(x => x.Id == updateCity.Id);

                if (city.User.Id == GetUserId())
                {


                    city.Name = updateCity.Name;
                    city.Populasyon = updateCity.Populasyon;
                    city.Class = updateCity.Class;

                    await _context.SaveChangesAsync();
                    serviceresponse.Data = _mapper.Map<GetCity>(city);
                }
                else
                {
                    serviceresponse.Success=false;
                    serviceresponse.Message = "Şehir Bulunamadı";
                }
            }
            catch (Exception ex)
            {

                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }

        public async Task<ServiceResponse<List<GetCity>>> DeleteCity(int id)
        {


            ServiceResponse<List<GetCity>> serviceresponse = new ServiceResponse<List<GetCity>>();



            try
            {
                CityEntity city = await _context.CityEntities.FirstOrDefaultAsync(x => x.Id == id && x.User.Id == GetUserId());
                if (city != null)
                {
                    _context.CityEntities.Remove(city);
                    await _context.SaveChangesAsync();
                    serviceresponse.Data = _context.CityEntities
                        .Where(x => x.User.Id == GetUserId())
                        .Select(x => _mapper.Map<GetCity>(x)).ToList();
                }
                else
                {
                    serviceresponse.Success = false;
                    serviceresponse.Message = "Şehir Bulunamadı";

                }
            }
            catch (Exception ex)
            {

                serviceresponse.Success = false;
                serviceresponse.Message = ex.Message;
            }
            return serviceresponse;
        }
    }
}
