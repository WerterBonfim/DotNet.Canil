using System;
using MongoDB.Driver;

namespace SIS.Canil.BancoDeDados.Suporte
{
    public abstract class SuporteDb
    {
        private IMongoClient _mongoClient { get; }
        //private readonly SuporteLog _suporteLog;
        protected IMongoDatabase Banco { get; set; }

        

        protected SuporteDb()
        {
            _mongoClient = new MongoClient(MontarStringDeConexao());
            DefinirBanco("canil");
        }

       

        private SuporteDb DefinirBanco(string nome)
        {
            Banco = _mongoClient.GetDatabase(nome);
            return this;
        }

        protected IMongoCollection<T> DefinirColecao<T>(string nome)
        {
            var colecao = Banco.GetCollection<T>(nome);
            return colecao;
        }

        private string MontarStringDeConexao()
        {
            if (ConfiguracaoDb.EstaInvalida())
                throw new Exception("A string de conexão está inválida");
        
            var stringDeConexao =
                $"mongodb://{ConfiguracaoDb.Usuario}:" +
                $"{ConfiguracaoDb.Senha}@" +
                $"{ConfiguracaoDb.Host}:" +
                $"{ConfiguracaoDb.Porta}/" +
                $"{ConfiguracaoDb.BancoAutenticancao}";

            return stringDeConexao;
        }
    }
}