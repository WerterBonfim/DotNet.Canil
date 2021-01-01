using System;
using Bogus.Extensions.Brazil;
using SIS.Canil.BancoDeDados.Repositorios;
using SIS.Canil.BancoDeDados.Suporte;
using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos.Cao;
using SIS.Canil.Negocio.Requisitos.Cliente;

namespace SIS.Canil.Testes
{
    public abstract class TesteBase
    {
        protected readonly IRepositorioDeClientes RepositorioDeClientes;
        protected readonly IRepositorioDeCaes RepositorioDeCaes;

        protected TesteBase()
        {
            ConfigurarMongoDbDocker();
            RepositorioDeClientes = new RepositorioDeClientes();
            RepositorioDeCaes = new RepositorioDeCaes();
        }

        private void ConfigurarMongoDbDocker()
        {
            ConfiguracaoDb.Banco = "canil";
            ConfiguracaoDb.Host = "localhost";
            ConfiguracaoDb.Porta = "27017";
            ConfiguracaoDb.Senha = "!123Senha";
            ConfiguracaoDb.Usuario = "mongo";
            ConfiguracaoDb.BancoAutenticancao = "admin";
        }

        protected RequisitosParaCadastrarCliente GerarUmCliente()
        {
            var fulano = new Bogus.Person("pt_BR");

            var cliente = new RequisitosParaCadastrarCliente(
                fulano.FirstName,
                fulano.Gender.ToString(),
                GerarRgFake(),
                fulano.Cpf(),
                fulano.DateOfBirth,
                fulano.Address.Street,
                NumeroResidencialFake(),
                fulano.Address.State,
                fulano.Address.Suite,
                fulano.Address.State
            );

            return cliente;
        }

        private static string NumeroResidencialFake()
        {
            return new Bogus.Randomizer().Number(1, 999).ToString();
        }

        private static string GerarRgFake()
        {
            var rg = new Bogus.Randomizer().Number(11).ToString();
            return rg;
        }


        public RequisitosParaCadastrarCao GerarUmCao()
        {
            var fake = new Bogus.Person("pt_BR");
            var cor = new Bogus.Faker().Commerce.Color();

            
            return new RequisitosParaCadastrarCao(
                fake.FirstName,
                DateTime.Now.AddYears(-7),
                fake.Gender.ToString(),
                cor
            );
        }
    }
}