using FluentValidation;
using MediatRWithAspNetCore.Dto;

namespace MediatRWithAspNetCore.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .WithMessage("O Nome do cliente é obrigatório");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("O Sobrenome do cliente é obrigatório");

            RuleFor(a => a.CellPhone)
                .NotEmpty()
                .WithMessage("O número de telefone é obrigatório");

            RuleFor(a => a.Email)
                .NotEmpty()
                .WithMessage("O endereço de email é obrigatório");
        }
    }
}
