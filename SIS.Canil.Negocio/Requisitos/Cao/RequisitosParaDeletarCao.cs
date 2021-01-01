using FluentValidation;
using MongoDB.Bson;

namespace SIS.Canil.Negocio.Requisitos.Cao
{
    public class RequisitosParaDeletarCao : RequisitosBase
    {
        public string Id { get; set; }

        public RequisitosParaDeletarCao()
        {
            
        }

        public RequisitosParaDeletarCao(string id)
        {
            Id = id;
        }

        public override bool EValido()
        {
            ResultadoDaValidacao = new ValidacaoParaDeletarUmCao().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }
        
        private sealed class ValidacaoParaDeletarUmCao : AbstractValidator<RequisitosParaDeletarCao>
        {
            public ValidacaoParaDeletarUmCao()
            {
                RuleFor(x => x.Id)
                    .Must(TerIdValido)
                    .WithMessage("Id informado é inválido");
            }

            
        }
    }
}