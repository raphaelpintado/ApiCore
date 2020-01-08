using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        private const string REQUIREDFIELDMESSAGE = "O campo {PropertyName} precisa ser fornecido";
        private const string SIZEFIELDMESSAGE = "O campo {PropertyName} precisa estar entre {MinLength} e {MaxLength} caracteres";
        private const string DOCUMENTSIZEMESSAGE = "O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.";
        private const string INVALIDDOCUMENTMESSAGE = "O documento fornecido é inválido.";

        public FornecedorValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(REQUIREDFIELDMESSAGE)
                .Length(2, 100).WithMessage(SIZEFIELDMESSAGE);

            When(x => x.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage(DOCUMENTSIZEMESSAGE);
                RuleFor(x => CpfValidacao.Validar(x.Documento)).Equal(true)
                    .WithMessage(INVALIDDOCUMENTMESSAGE);
            });

            When(x => x.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(x => x.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage(DOCUMENTSIZEMESSAGE);
                RuleFor(x => CnpjValidacao.Validar(x.Documento)).Equal(true)
                    .WithMessage(INVALIDDOCUMENTMESSAGE);
            });
        }
    }
}
