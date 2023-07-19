using FluentValidation;
using SmartHintDev.Domain.Core.Utils;
using SmartHintDev.Domain.Models;

namespace SmartHintDev.Domain.Validacao
{
    public class CLienteValidacaoService : AbstractValidator<Cliente>
    {
        public CLienteValidacaoService()
        {
            RuleFor(c => c.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id é obrigatório.");

            RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage("O Nome é obrigatório.");

            RuleFor(c => c.Telefone)
             .NotEmpty()
             .WithMessage("O Telefone é obrigatório.");

            RuleFor(c => c.TipoPessoa)
             .NotEmpty()
             .WithMessage("O Tipo de Pessoa é obrigatório.");

            RuleFor(c => c.CpfCnpj)
             .Must(HasValidarCpf)
             .When(c => !string.IsNullOrEmpty(c.CpfCnpj))
             .WithMessage("O Cpf/Cnpj informado não é valido.");
           
            RuleFor(c => c.InscricaoEstadual)
            .Length(1, 12)
            .WithMessage("A Inscrição Estadual deve ter no máximo 12 caracteres.");

            RuleFor(c => c.Senha)
                .NotEmpty()
                .WithMessage("A Senha é obrigatório.");

        }

        protected static bool HasValidarCpf(string cpf)
        {
            return CpfCnpjValidacao.ValidarCnpjCpf(cpf);
        }
    }
}
