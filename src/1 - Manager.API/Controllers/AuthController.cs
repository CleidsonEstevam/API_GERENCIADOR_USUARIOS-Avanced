using System;
using Manager.API.Token;
using Manager.API.Utilites;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Manager.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenService;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
        }
        
        [HttpPost]
        [Route("/api/v1/auth/login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                 var tokenLogin    = _configuration["Jwt:Login"];
                 var tokenPassword = _configuration["Jwt:Password"];

            if (loginViewModel.login == tokenLogin && loginViewModel.senha == tokenPassword)
                return Ok(new ResultViewModel
                {
                    Message = "Usuário autenticado com sucesso!",
                    Success = true,
                    Data = new
                    {
                        Token = _tokenService.GenerateToken(),
                        TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                    }
                });
            else
                return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
           
        }
    }
}
