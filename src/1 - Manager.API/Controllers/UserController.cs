using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Manager.Core.Exceptions;
using Manager.API.ViewModels;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.API.Utilites;

namespace Manager.API.Controllers 
{
    [ApiController]
    public class UserController : ControllerBase
    {
          public readonly IUserService _userService;
          public readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
         [Route("api/v1/users/create")]
         public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
         {
             var userDTO = _mapper.Map<UserDTO>(userViewModel);
             var userCreated =  await _userService.Crate(userDTO);
             
             try 
             {
               return Ok(new ResultViewModel{
                 Message = "Usuário criado com sucesso.",
                 Success = true,
                 Data = userCreated
               });
             }
             catch(DomainException ex)
             {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
             }
             catch(Exception)
             {
                return StatusCode(500, Responses.AplicationErrorMessage());
             }
         }
    }
}