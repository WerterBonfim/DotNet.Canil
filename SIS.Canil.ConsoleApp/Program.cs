using System;
using System.Linq;
using MongoDB.Driver;
using SIS.Canil.BancoDeDados.Repositorios;
using SIS.Canil.BancoDeDados.Suporte;
using SIS.Canil.Negocio.Colecoes;
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

            BuscarCliente();
        }

        

        private static void CadastrandoUmCliente()
        {
            Console.WriteLine("Cadastrando um cliente qualquer");
            
            var requisitosParaCadastrarUmCliente = new RequisitosParaCadastrarCliente(
                // txtNomeCliente.txt ...
                nome:"Fulano",
                cpf: "411.660.960-92"
            );

            var servico = new LidarComCriacaoDeCliente(new RepositorioDeClientes());
            var resultado = servico.LidarCom(requisitosParaCadastrarUmCliente);
            if (resultado.IsValid)
                Console.WriteLine("O cliente foi cadastrado com sucesso");
            else
            {
                Console.WriteLine("Não foi possivel cadastrar o cliente:");
                var primeiroErro = resultado.Errors
                    .FirstOrDefault();
                Console.WriteLine(primeiroErro);
            }
        }
        
        
        private static void BuscarCliente()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Listando os clientes");
            
            var repositorio = new RepositorioDeClientes();
            //repositorio.Listar(x => x.Nome == "Fulano" );
            //repositorio.Listar(x => x.Cpf == "41166096092");
            var clientes = repositorio.Listar();
            foreach (var cliente in clientes)
                Console.WriteLine(cliente.ToString());
            
        }
    }
}