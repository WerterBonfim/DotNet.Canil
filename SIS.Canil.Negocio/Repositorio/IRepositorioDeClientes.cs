using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SIS.Canil.Negocio.Colecoes;

namespace SIS.Canil.Negocio.Repositorio
{
    public interface IRepositorioDeClientes
    {
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(ObjectId id);
        Cliente BuscarPorCpf(string cpf);
        Cliente BuscarPorId(string id);
        IList<Cliente> Listar(FilterDefinition<Cliente> filtro,  int pagina = 1, int qtdPorPagina = 10);
    }
}