using MongoDB.Bson;
using SIS.Canil.Negocio.Colecoes;

namespace SIS.Canil.Negocio.Repositorio
{
    public interface IRepositorioDeClientes
    {
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(ObjectId id);
        Cliente BuscarPorCpf(string cpf);
    }
}