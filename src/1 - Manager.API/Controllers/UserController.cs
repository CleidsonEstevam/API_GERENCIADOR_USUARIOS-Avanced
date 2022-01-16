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
         [HttpDelete]
         [Route("api/v1/users/delete/{id}")]
          public async Task<IActionResult> Remove(long id)
         {
             try 
             {
               await _userService.Remove(id);

               return Ok(new ResultViewModel{
                 Message = "Usuário removido com sucesso.",
                 Success = true,
                 Data = null
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

          [HttpGet]
         [Route("api/v1/users/get/{id}")]
          public async Task<IActionResult> Get(long id)
         {
             try 
             {
               var user = await _userService.Get(id);

               if(user == null)
               return Ok(new ResultViewModel{
                 Message = "ID informado não pertence a nenhum usuário.",
                 Success = true,
                 Data = user
               });

               return Ok(new ResultViewModel{
                 Message = "Usuário encontrado comm sucesso.",
                 Success = true,
                 Data = user
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

          [HttpGet]
         [Route("api/v1/users/get/get-all")]
          public async Task<IActionResult> Get()
         {
             try 
             {
               var allUsers = await _userService.Get();

               return Ok(new ResultViewModel{
                 Message = "Usuários encontrado comm sucesso.",
                 Success = true,
                 Data = allUsers
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

         [HttpGet]
         [Route("api/v1/users/get-by-email")]
         public async Task<ActionResult> GetByEmail(string email)
         {
           try
           {
             var user = await _userService.GetByEmail(email);

             if(user == null)
               return Ok(new ResultViewModel{
                 Message = "Nenhum e-mail foi encontrado.",
                 Success = true,
                 Data = user
               });

               return Ok(new ResultViewModel{
                 Message = "Usuário encontrado com sucesso.",
                 Success = true,
                 Data = user
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

          [HttpGet]
         [Route("api/v1/users/search-by-name")]
         public async Task<ActionResult> SearchByName([FromBody] string name)
         {
           try
           {
             var allUsers = await _userService.SearchByName(name);
             
             if(allUsers.Count == 0)
               return Ok(new ResultViewModel{
                 Message = "Nenhum usuário encontrado com esse nome.",
                 Success = true,
                 Data = allUsers
               });

               return Ok(new ResultViewModel{
                 Message = "Usuário encontrado com sucesso.",
                 Success = true,
                 Data = allUsers
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

        [HttpGet]
         [Route("api/v1/users/search-by-email")]
         public async Task<ActionResult> SearchByEmail([FromBody] string email)
         {
           try
           {
             var allUsers = await _userService.SearchByName(email);
             
             if(allUsers.Count == 0)
               return Ok(new ResultViewModel{
                 Message = "Nenhum usuário encontrado com esse email.",
                 Success = true,
                 Data = allUsers
               });
               
               return Ok(new ResultViewModel{
                 Message = "Usuário encontrado com sucesso.",
                 Success = true,
                 Data = allUsers
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