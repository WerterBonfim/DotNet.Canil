using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SIS.Canil.BancoDeDados.Suporte;
using SIS.Canil.Negocio;
using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Repositorio;
using B = MongoDB.Driver.Builders<SIS.Canil.Negocio.Colecoes.Cliente>; 

namespace SIS.Canil.BancoDeDados.Repositorios
{
    public class RepositorioDeClientes : SuporteDb, IRepositorioDeClientes
    {
        private readonly IMongoCollection<Cliente> _clientes;

        public RepositorioDeClientes()
        {
            _clientes = DefinirColecao<Cliente>("clientes");
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                _clientes.InsertOne(cliente);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um novo cliente", e);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                var teste = _clientes.ReplaceOne(
                    filter: B.Filter.Eq(x => x.Id == cliente.Id, true),
                    replacement: cliente
                );
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar atualizar um cliente", e);
            }
            
        }

        public void Deletar(ObjectId id)
        {
            try
            {
                var resultado = _clientes.DeleteOne(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar deletar um cliente", e);
            }
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            var cliente = _clientes
                .Find(B.Filter.Eq(x => x.Cpf, cpf))
                .FirstOrDefault();

            return cliente;

        }
    }
}