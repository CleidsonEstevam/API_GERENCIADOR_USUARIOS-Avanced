using System;
using System.Collections.Generic;
using Manager.Domain.Validations;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        //--Só é possivel mudar a entidade passando por validação, impedido de adicionar dados falsos a entidade--
        /*
          var user = new User("Nome1");
          user.Name = "Nome2";
          repositorio.Atualizar(user);

          --> é feita a verificação se o método estiver invalido ele vai retornar um erro -- 
        */
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //Construtor vazio para deixar a entidade aberta para o EF
        protected User(){}

        //Construtor que determina os parâmetros que a entidade vai receber
         public User(string name, string email, string password)
        {
            Name      = name;
            Email     = email;
            Password  = password;
            _errors = new List<string>();
        }

        //Métodos da entidade, comportamentos que cada propriedade vai ter
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }


        //auto validação
        public override bool Validate()
        {
           var validator = new UserValidator(); 
           //Pedido para validadr ESTÁ(this) classe. 
           var validation = validator.Validate(this);

           if(!validation.IsValid)
           {
               foreach(var error in validation.Errors)
               {
                     _errors.Add(error.ErrorMessage);              

                    throw new Exception("Alguns campos inválidos" + _errors[0]);
               }
           }
           //Se a entidade tiver ok, ele retorna true se não retorna a exeção
            return true;
        }
    }
}