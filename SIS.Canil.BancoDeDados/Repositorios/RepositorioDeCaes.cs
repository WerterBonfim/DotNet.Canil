using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Repositorio;

namespace SIS.Canil.BancoDeDados.Repositorios
{
    public sealed class RepositorioDeCaes : RepositorioBase<Cao>, IRepositorioDeCaes
    {
        public RepositorioDeCaes() : base("caes")
        {
        }

        public void Inserir(Cao cao)
        {
            try
            {
                Colecao.InsertOne(cao);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um novo cao", e);
            }
        }

        public void Atualizar(Cao cao)
        {
            try
            {
                var resultado = Colecao.ReplaceOne(x => x.Id == cao.Id, cao);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um novo cao", e);
            }
        }

        public void Deletar(ObjectId id)
        {
            try
            {
                Colecao.DeleteOne(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um novo cao", e);
            }
        }

        public Cao BuscarPorId(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var cao = Colecao
                    .Find(x => x.Id == objectId)
                    .FirstOrDefault();

                return cao;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um novo cao", e);
            }
        }

        public IList<Cao> Listar(FilterDefinition<Cao> filtro = null, int pagina = 1, int qtdPorPagina = 10)
        {
            try
            {
                var caes = FiltrarCollecao(filtro, pagina, qtdPorPagina);
                return caes;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar listar os caes", e);
            }
        }

        public bool Existe(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                var cao = Colecao.Find(x => x.Id == objectId)
                    .FirstOrDefault();

                return cao == null;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorre um erro ao tentar verificar se um cão existe na base de dados", e);
            }
        }
    }
}