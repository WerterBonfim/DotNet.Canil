using System;

namespace SIS.Canil.Negocio.Requisitos.Cao
{
    public sealed class RequisitosParaCadastrarCao : RequisitosDoCaoBase
    {
        public RequisitosParaCadastrarCao()
        {
            
        }

        public RequisitosParaCadastrarCao(
            string nome = null, 
            DateTime dataDeNascimento = default,
            string sexo = null, 
            string corDoAnimal = null, 
            string pedgree = null, 
            string observacoes = null) : 
            base(nome, dataDeNascimento, sexo, corDoAnimal, pedgree, observacoes)
        {
            
        }
    }
}