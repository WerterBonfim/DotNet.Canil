using FluentValidation;
using MongoDB.Bson;

namespace SIS.Canil.Negocio.Requisitos.Cliente
{
    public class RequisitosParaDeletarCliente : RequisitosBase
    {
        public ObjectId Id { get; set; }

        public RequisitosParaDeletarCliente()
        {
        }

        public RequisitosParaDeletarCliente(ObjectId id)
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

            private bool TerIdValido(ObjectId id)
            {
                return ObjectId.TryParse(id.ToString(), out _);
            }
        }
    }
}