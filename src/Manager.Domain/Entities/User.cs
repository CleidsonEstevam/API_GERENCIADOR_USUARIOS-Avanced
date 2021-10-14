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

         public User(string name, string email, string password)
        {
            Name      = name;
            Email     = email;
            Password  = password;
        }
    }
}