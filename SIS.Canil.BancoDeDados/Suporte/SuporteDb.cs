﻿using MongoDB.Driver;

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
            //MontarColecoes();
        }

        // private void MontarColecoes()
        // {
        //     Pessoas = DefinirColecao<BsonDocument>("pessoas");
        // }

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
            var stringDeConexao =
                $"mongodb://{ConfiguracaoDb.Usuario}:" +
                $"{ConfiguracaoDb.Senha}@" +
                $"{ConfiguracaoDb.Host}:" +
                $"{ConfiguracaoDb.Porta}/" +
                $"{ConfiguracaoDb.BancoAutenticancao}";

            return stringDeConexao;
        }

        // private MongoClientSettings MontarConexaoComLog()
        // {
        //     var configuracoes = new MongoClientSettings
        //     {
        //         Server = new MongoServerAddress(ConfiguracaoDb.Host, ConfiguracaoDb.Porta),
        //         Credential = MongoCredential.CreateCredential(
        //             ConfiguracaoDb.Banco,
        //             ConfiguracaoDb.Usuario,
        //             ConfiguracaoDb.Senha),
        //
        //         ClusterConfigurator = cb =>
        //             cb.Subscribe<CommandStartedEvent>(x =>
        //                 _suporteLog.LogarEvento(x))
        //     };
        //
        //     return configuracoes;
        // }
    }
}