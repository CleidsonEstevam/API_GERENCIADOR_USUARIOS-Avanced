using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            //Validação para a entidade num geral 
            RuleFor(x => x)
                .NotEmpty() 
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A Entidade não pode ser nula.");
                
            //Validação para a propriedade Nome da Entidade
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres");

            //Validação Email
            RuleFor(x => x.Email)
            .NotNull()
                .WithMessage("O Email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O Email não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O Email deve ter no mínimo 10 caracteres.")

                .MaximumLength(180)
                .WithMessage("O Email deve ter no máximo 180 caracteres")

                //Aplicar expressão regular para verificar se é um e-mail. 
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

                 RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A Senha não pode ser nulo.")

                .NotEmpty()
                .WithMessage("A Senha não pode ser vazio.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MaximumLength(30)
                .WithMessage("A senha ter no máximo 30 caracteres");
        }
    }
}