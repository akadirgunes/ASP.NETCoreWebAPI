﻿using CityAPI.Core;
using CityAPI.Core.Dtos.User;
using CityAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _autoRepo;

        public AuthController(IAuthRepository autoRepo)
        {
            _autoRepo = autoRepo;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _autoRepo.Register(new UserEntity
            {Username = request.Username }, request.Password
            );
            if(!response.Success) 
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLogin request)
        {
            var response = await _autoRepo.Login(request.Username,request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }


    }
}
