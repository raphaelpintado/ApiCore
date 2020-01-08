using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        private const string REQUIREDFIELDMESSAGE = "O campo {PropertyName} precisa ser fornecido";
        private const string SIZEFIELDMESSAGE = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";
        private const string MAXLENGTHFIELDMESSAGE = "O campo {PropertyName} precisa ter {MaxLength} caracteres";

        public EnderecoValidation()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 200).WithMessage(SIZEFIELDMESSAGE);

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 100).WithMessage(SIZEFIELDMESSAGE);

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(8).WithMessage(MAXLENGTHFIELDMESSAGE);

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 100).WithMessage(SIZEFIELDMESSAGE);

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 50).WithMessage(SIZEFIELDMESSAGE);

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(1, 50).WithMessage(SIZEFIELDMESSAGE);
        }
    }
}
