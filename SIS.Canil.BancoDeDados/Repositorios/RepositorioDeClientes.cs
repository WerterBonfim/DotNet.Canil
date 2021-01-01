using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Repositorio;
 

namespace SIS.Canil.BancoDeDados.Repositorios
{
    public class RepositorioDeClientes : RepositorioBase<Cliente>, IRepositorioDeClientes
    {

        public RepositorioDeClientes() : base("clientes")
        {
            
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                Colecao.InsertOne(cliente);
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
                var teste = Colecao
                    .ReplaceOne(x => x.Id == cliente.Id, cliente);
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
                var resultado = Colecao.DeleteOne(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar deletar um cliente", e);
            }
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            cpf = cpf
                .Replace(".", "")
                .Replace("-", "");
            
            var cliente = Colecao
                .Find(x => x.Cpf == cpf)
                .FirstOrDefault();

            return cliente;

        }

        public Cliente BuscarPorId(string id)
        {
            var objectId = ObjectId.Parse(id);
            
            var cliente = Colecao
                .Find(x => x.Id == objectId)
                .FirstOrDefault();
            
            //_clientes.CountDocuments(x => x.Id == objectId)
            
            return cliente;
        }
        
        public IList<Cliente> Listar(Func<Cliente, bool> filtro = null, int pagina = 0, int qtdPorPagina = 10)
        {
            try
            {
                var clientes = FiltrarCollecao(filtro, pagina, qtdPorPagina)
                    .OrderBy(x => x.Id)
                    .ToList();
                
                return clientes;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar listar os clientes", e);
            }
        }

        
        
    }
}