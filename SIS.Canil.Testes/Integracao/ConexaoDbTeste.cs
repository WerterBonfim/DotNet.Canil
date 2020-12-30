using FluentAssertions;
using SIS.Canil.BancoDeDados.Suporte;
using Xunit;

namespace SIS.Canil.Testes.Integracao
{
    public class ConexaoDbTeste
    {
        [Fact(DisplayName = "Conexão inválida")]
        [Trait("Conexao com MongoDB", "Inválida")]
        public void DeveNotificarUmaConexaoInvalida()
        {
            ConfiguracaoDb.EstaInvalida()
                .Should()
                .BeTrue("nenhum parametro foi passado");

            ConfiguracaoDb.Banco = "banco";
            ConfiguracaoDb.Host = "host";
            ConfiguracaoDb.Porta = "30";
            ConfiguracaoDb.Usuario = "usuario";
            ConfiguracaoDb.Senha = "senha";
            //ConfiguracaoDb.BancoAutenticancao = "vazio";
            
            ConfiguracaoDb.EstaInvalida()
                .Should()
                .BeTrue("o parametro BancoAutenticacao nao foi fornecido");
        }
    }
}