using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O Nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Nome deve ter no máximo 80 caracteres.")]
        public string Name    { get; private set; }

        [Required(ErrorMessage = "O Email não pode ser nulo.")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no máximo 80 caracteres.")]
        //Falta add regular expression do email
        public string Email    { get; private set; }

        [Required(ErrorMessage = "O Password não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O Password deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Password deve ter no máximo 80 caracteres.")]
        public string Password { get; private set; }

    }
}