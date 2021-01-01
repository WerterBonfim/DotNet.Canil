using System;
using FluentValidation;

namespace SIS.Canil.Negocio.Requisitos.Cao
{
    public class RequisitosDoCaoBase : RequisitosBase
    {
        public RequisitosDoCaoBase(
            string nome = null, 
            DateTime dataDeNascimento = default, 
            string sexo = null, 
            string corDoAnimal = null, 
            string pedgree = null, 
            string observacoes = null
            )
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            CorDoAnimal = corDoAnimal;
            Pedgree = pedgree;
            Observacoes = observacoes;
        }

        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string CorDoAnimal { get; set; }
        public string Pedgree { get; set; }
        public string Observacoes { get; set; }

        public override bool EValido()
        {
            ResultadoDaValidacao = new ValidacaoCaoBase().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }
        
        
        
        private sealed class ValidacaoCaoBase : AbstractValidator<RequisitosDoCaoBase>
        {
            public ValidacaoCaoBase()
            {
                When(c => c.DataDeNascimento != default, () =>
                {
                    RuleFor(x => x.DataDeNascimento)
                        .GreaterThan(DateTime.Now.AddYears(-30))
                        .WithMessage("Data informada é inválida");
                });
                
                // caso haja mais validações, implemente aqui em baixo
            }
        }
        
        
    }
}