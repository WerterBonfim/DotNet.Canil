using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Requisitos.Cao;

namespace SIS.Canil.Negocio.Conversor
{
    public static class CaoConversor
    {
        public static Cao ConverterParaCao(this RequisitosDoCaoBase requisitos, string id = null)
        {
            return new Cao(
                requisitos.Nome,
                requisitos.DataDeNascimento,
                requisitos.Sexo,
                requisitos.CorDoAnimal,
                requisitos.Pedgree,
                requisitos.Observacoes,
                id
            );
        }
    }
}