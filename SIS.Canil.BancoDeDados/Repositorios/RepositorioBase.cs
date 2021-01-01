using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SIS.Canil.BancoDeDados.Suporte;

namespace SIS.Canil.BancoDeDados.Repositorios
{
    public abstract class RepositorioBase<C> : SuporteDb where C : class
    {
        protected readonly IMongoCollection<C> Colecao;
        
        public RepositorioBase(string nomeColecao)
        {
            Colecao = DefinirColecao<C>(nomeColecao);
        }

        protected IList<C> FiltrarCollecao(FilterDefinition<C> filtro = null, int pagina = 1, int qtdPorPagina = 10)
        {
            var pular = pagina * qtdPorPagina;
            IFindFluent<C, C> filtroFluente = null;

            filtroFluente = filtro == null ? 
                Colecao.Find(x => true) : 
                Colecao.Find(filtro);

            var caes = filtroFluente
                .Limit(qtdPorPagina)
                .Skip(pular)
                .ToList();

            return caes;
        }
        
        

    }
}