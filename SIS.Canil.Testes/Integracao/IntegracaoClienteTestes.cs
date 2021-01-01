using System;
using System.Linq;
using System.Threading;
using FluentAssertions;
using SIS.Canil.Negocio.Requisitos.Cliente;
using SIS.Canil.Servicos.ServicosDeCliente;
using Xunit;
using Xunit.Abstractions;

namespace SIS.Canil.Testes.Integracao
{
    /// <summary>
    /// Para rodar corretamente os testes é preciso configurar na classe TesteBase
    /// a string de conexão com o MongoDB. Estou utilizando o Docker para isso.
    /// </summary>
    public class IntegracaoClienteTestes : TesteBase
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public IntegracaoClienteTestes(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact(DisplayName = "Deve registrando um cliente no banco de dados")]
        [Trait("Cliente", "Inserir")]
        public void DeveCadastrarUmCliente()
        {
            // string de conexão que depende do Docker

            var requisitos = GerarUmCliente();
            var servico = new LidarComCriacaoDeCliente(RepositorioDeClientes);
            var resultado = servico.LidarCom(requisitos);

            resultado.Errors
                .Should()
                .BeEmpty();
        }

        [Fact(DisplayName = "Deve notificar erro para CPF já cadastrado no banco")]
        [Trait("Cliente", "Inserir")]
        public void DeveNotificarUmErroParaCpfJaCadastrado()
        {
            // string de conexão que depende do Docker

            var requisitos = GerarUmCliente();
            var servico = new LidarComCriacaoDeCliente(RepositorioDeClientes);
            var resultado = servico.LidarCom(requisitos);

            resultado.Errors
                .Should()
                .BeEmpty("um novo cliente foi gerado via lib Bogus");

            resultado = servico.LidarCom(requisitos);

            var erros = resultado.Errors;

            erros
                .Should()
                .NotBeEmpty();

            erros.FirstOrDefault()
                ?.ErrorMessage
                .Should()
                .BeEquivalentTo("Este CPF já está em uso");
        }

        [Fact(DisplayName = "Deve deletar um cliente do banco")]
        [Trait("Cliente", "Deletar")]
        public void DeveDeletarUmClienteComSucesso()
        {
            var requisitosParaCadastrarCliente = GerarUmCliente();

            var servico = new LidarComCriacaoDeCliente(RepositorioDeClientes);
            servico.LidarCom(requisitosParaCadastrarCliente);

            var cpf = requisitosParaCadastrarCliente.Cpf;
            var cliente = RepositorioDeClientes.BuscarPorCpf(cpf);
            var requisitoParaDeletar = new RequisitosParaDeletarCliente(cliente.Id.ToString());
            var servicoDeleteCliente = new LidarComDeleteCliente(RepositorioDeClientes);
            var resultado = servicoDeleteCliente.LidarCom(requisitoParaDeletar);

            resultado.Errors
                .Should()
                .BeEmpty("foi previamente cadastrado um cliente");
        }

        [Fact(DisplayName = "Deve alterar um cliente com sucesso")]
        [Trait("Cliente", "Alterar")]
        public void DeveAlterarUmClienteComSucesso()
        {
            var novoCliente = GerarUmCliente();
            CadastrarUmCliente(novoCliente);

            var cliente = RepositorioDeClientes.BuscarPorCpf(novoCliente.Cpf);
            var requisitoParaAlterar = new RequisitosParaAlterarCliente(
                cliente.Id.ToString(),
                cliente.Nome,
                cliente.Sexo,
                cliente.RG,
                cliente.Cpf,
                cliente.DataNascimento,
                cliente.Endereço,
                cliente.NumeroCasa,
                cliente.Bairro,
                cliente.Municipio,
                cliente.UF,
                cliente.Localização,
                cliente.Complemento,
                cliente.EstadoCivil,
                cliente.Nacionalidade,
                cliente.WhatsApp,
                cliente.TelefoneFixo,
                cliente.Celular,
                cliente.Facebook,
                cliente.Instagram,
                cliente.Observação
            );
            var servicoAlterarCliente = new LidarComAlteracaoDeCliente(RepositorioDeClientes);
            var resultado = servicoAlterarCliente.LidarCom(requisitoParaAlterar);

            resultado.Errors
                .Should()
                .BeEmpty("foi previamente cadastrado um cliente");
        }

        [Fact(DisplayName = "Deve listar os 3 ultimos clientes cadastrados")]
        [Trait("Cliente", "Filtro")]
        public void DeveListarOsUltimes3ClientesCadastrados()
        {
            var clientes = Enumerable.Range(0, 4)
                .Select(x => GerarUmCliente());

            var servico = new LidarComCriacaoDeCliente(RepositorioDeClientes);
            foreach (var cliente in clientes)
            {
                // simula um delay de 1 segundo
                Thread.Sleep(TimeSpan.FromSeconds(1));
                servico.LidarCom(cliente);
            }
            
            var ultimosClientes = RepositorioDeClientes.Listar(qtdPorPagina: 3);
            var primeiro = ultimosClientes.First();
            var ultimo = ultimosClientes.Last();

            foreach (var cliente in ultimosClientes)
                _testOutputHelper.WriteLine(cliente.ToString());

            primeiro.Id.CreationTime
                .Should()
                .BeAfter(ultimo.Id.CreationTime);
        }

        private void CadastrarUmCliente(RequisitosParaCadastrarCliente novoCliente)
        {
            var servico = new LidarComCriacaoDeCliente(RepositorioDeClientes);
            servico.LidarCom(novoCliente);
        }
    }
}