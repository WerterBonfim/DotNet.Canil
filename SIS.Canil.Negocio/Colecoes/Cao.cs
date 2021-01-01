using System;

namespace SIS.Canil.Negocio.Colecoes
{
    public sealed class Cao : ColecaoBase
    {
        
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string CorDoAnimal { get; set; }
        public string Pedgree { get; set; }
        public string Observacoes { get;  set; }

        public Cao(
            string nome = null, 
            DateTime dataDeNascimento = default, 
            string sexo = null, 
            string corDoAnimal = null, 
            string pedgree = null, 
            string observacoes = null,
            string id = null    
            ) : base(id)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            CorDoAnimal = corDoAnimal;
            Pedgree = pedgree;
            Observacoes = observacoes;
        }
        
        

        
    }
}