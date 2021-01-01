using FluentValidation;

namespace SIS.Canil.Negocio.Requisitos.Cao
{
    public class RequisitosParaExcluirCao : RequisitosBase
    {
        public string Id { get; set; }

        public RequisitosParaExcluirCao()
        {
            
        }

        public RequisitosParaExcluirCao(string id)
        {
            Id = id;
        }
        
        public override bool EValido()
        {
            ResultadoDaValidacao = new ValidacaoParaDeletarUmCao().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }
        
        private sealed class ValidacaoParaDeletarUmCao : AbstractValidator<RequisitosParaExcluirCao>
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