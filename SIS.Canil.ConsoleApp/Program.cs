using System;
using System.Linq;
using SIS.Canil.BancoDeDados.Repositorios;
using SIS.Canil.BancoDeDados.Suporte;
using SIS.Canil.Negocio.Requisitos.Cliente;
using SIS.Canil.Servicos.ServicosDeCliente;

namespace SIS.Canil.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema DotNet.Canil");
            
            // Seu projeto UI deve referencias as libs: Negocio e Serviço

            // Configurando a string de conexão
            ConfiguracaoDb.Banco = "canil";
            ConfiguracaoDb.Host = "localhost";
            ConfiguracaoDb.Porta = "27017";
            // Eu configurei essa senha, altere para a senha que você definiu na instalação
            ConfiguracaoDb.Usuario = "mongo";
            ConfiguracaoDb.Senha = "!123Senha";
            
            ConfiguracaoDb.BancoAutenticancao = "admin";

            // cadastrando um cliente
            CadastrandoUmCliente();
        }

        private static void CadastrandoUmCliente()
        {
            var requisitosParaCadastrarUmCliente = new RequisitosParaCadastrarCliente(
                // txtNomeCliente.txt ...
                "Fulano"
            );

            var servico = new LidarComCriacaoDeCliente(new RepositorioDeClientes());
            var resultado = servico.LidarCom(requisitosParaCadastrarUmCliente);
            if (resultado.IsValid)
                Console.WriteLine("O cliente foi cadastrado com sucesso");
            else
            {
                var primeiroErro = resultado.Errors
                    .FirstOrDefault();
                Console.WriteLine(primeiroErro);
            }
        }
    }
}