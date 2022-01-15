using System.Collections.Generic;
using Manager.API.ViewModels;

namespace Manager.API.Utilites
{
    //static para que possa ser usado sem instanciar
    public static class Responses
    {
        public static ResultViewModel AplicationErrorMessage()
        {
            return new ResultViewModel
            {
              Message = "Ocorreu algum erro na aplicação, por favor tente novamente",
              Success = false,
              Data = null  
            };
        }
         public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
              Message = message,
              Success = false,
              Data = null  
            };
        }
         public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
              Message = message,
              Success = false,
              Data = null  
            };
        }
        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
              Message = "A combinação de LOGIN e SENHA está incorreta!",
              Success = false,
              Data = null  
            };
        }
    }
}