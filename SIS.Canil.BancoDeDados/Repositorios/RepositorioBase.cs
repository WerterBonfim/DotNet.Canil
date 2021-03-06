using System;
using System.Collections.Generic;
using System.Linq;
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

        
        protected IEnumerable<C> FiltrarCollecao(Func<C, bool> filtro = null)
        {
            // Retorna todos
            Func<C, bool> filtroPadrao = x => true;

            if (filtro != null)
                filtroPadrao = filtro;

            var query = Colecao.AsQueryable()
                .Where(filtroPadrao);

            return query;
        }

        protected int CalcularPaginacao(int pagina = 0, int qtdPorPagina = 10)
        {
            return pagina * qtdPorPagina;
        }
        
        

    }
}