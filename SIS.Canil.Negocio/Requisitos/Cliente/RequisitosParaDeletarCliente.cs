using FluentValidation;
using MongoDB.Bson;

namespace SIS.Canil.Negocio.Requisitos.Cliente
{
    public class RequisitosParaDeletarCliente : RequisitosBase
    {
        public string Id { get; set; }

        public RequisitosParaDeletarCliente()
        {
        }

        public RequisitosParaDeletarCliente(string id)
        {
            Id = id;
        }

        public override bool EValido()
        {
            ResultadoDaValidacao = new ValidacaoParaDeletarUmCliente().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }
        
        private sealed class ValidacaoParaDeletarUmCliente : AbstractValidator<RequisitosParaDeletarCliente>
        {
            public ValidacaoParaDeletarUmCliente()
            {
                RuleFor(x => x.Id)
                    .Must(TerIdValido)
                    .WithMessage("Id informado é inválido");
            }

            
        }
    }
}