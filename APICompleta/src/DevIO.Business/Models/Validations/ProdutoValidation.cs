using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        private const string REQUIREDFIELDMESSAGE = "O campo {PropertyName} precisa ser fornecido";
        private const string SIZEFIELDMESSAGE = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";
        private const string GREATERTHANFIELDMESSAGE = "O campo {PropertyName} precisa ser maior que {ComparisonValue}";

        public ProdutoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 200).WithMessage(SIZEFIELDMESSAGE);

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 1000).WithMessage(SIZEFIELDMESSAGE);

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage(GREATERTHANFIELDMESSAGE);
        }
    }
}
