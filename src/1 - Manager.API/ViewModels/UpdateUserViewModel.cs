using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser nulo.")]
        [MinLength(1, ErrorMessage = "O ID não pode ser menor que 1.")]
      public int Id { get; set; }

        [Required(ErrorMessage = "O Nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Nome deve ter no máximo 80 caracteres.")]
        public string Name    { get;  set; }

        [Required(ErrorMessage = "O Email não pode ser nulo.")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no máximo 80 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Email    { get;  set; }

        [Required(ErrorMessage = "O Password não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O Password deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O Password deve ter no máximo 80 caracteres.")]
        public string Password { get;  set; }
    }
}