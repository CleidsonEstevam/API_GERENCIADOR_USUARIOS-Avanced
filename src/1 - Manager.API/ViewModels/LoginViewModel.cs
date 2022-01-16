using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login não pode ser vazio.")]
        public string login { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        public string senha { get; set; }

    }
}