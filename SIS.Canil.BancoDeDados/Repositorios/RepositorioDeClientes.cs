using System;
using MongoDB.Driver;
using SIS.Canil.BancoDeDados.Suporte;
using SIS.Canil.Negocio;
using SIS.Canil.Negocio.Colecoes;
using B = MongoDB.Driver.Builders<SIS.Canil.Negocio.Colecoes.Cliente>; 

namespace SIS.Canil.BancoDeDados.Repositorios
{
    public class RepositorioDeClientes : SuporteDb
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
    }
}