using System;
using FluentValidation;

namespace SIS.Canil.Negocio.Requisitos.Cao
{
    public class RequisitosParaAlterarCao : RequisitosDoCaoBase
    {
        public string Id { get; set; }
        
        public RequisitosParaAlterarCao()
        {
            
        }

        public RequisitosParaAlterarCao(
            string id, 
            string nome = null, 
            DateTime dataDeNascimento = default, 
            string sexo = null, 
            string corDoAnimal = null, 
            string pedgree = null, 
            string observacoes = null) : base(nome, dataDeNascimento, sexo, corDoAnimal, pedgree, observacoes)
        {
            Id = id;
        }
        
        private sealed class ValidacaoParaAlterarCao : AbstractValidator<RequisitosParaAlterarCao>
        {
            public ValidacaoParaAlterarCao()
            {
                RuleFor(x => x.Id)
                    .Must(TerIdValido);
            }
        }
    }
}