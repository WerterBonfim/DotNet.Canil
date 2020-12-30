using System.Linq;
using FluentAssertions;
using SIS.Canil.Negocio.Requisitos.Cliente;
using SIS.Canil.Servicos.ServicosDeCliente;
using Xunit;

namespace SIS.Canil.Testes.Integracao
{
    
    public class IntegracaoClienteTestes : TesteBase
    {

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
            var requisitoParaDeletar = new RequisitosParaDeletarCliente(cliente.Id);
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
            var requisitosParaCadastrarCliente = GerarUmCliente();

            var servico = new LidarComCriacaoDeCliente(RepositorioDeClientes);
            servico.LidarCom(requisitosParaCadastrarCliente);

            var cpf = requisitosParaCadastrarCliente.Cpf;
            var cliente = RepositorioDeClientes.BuscarPorCpf(cpf);
            // var requisitoParaDeletar = new RequisitosParaAlterarCliente();
            // var servicoDeleteCliente = new LidarComDeleteCliente(RepositorioDeClientes);
            // var resultado = servicoDeleteCliente.LidarCom(requisitoParaDeletar);
            //
            // resultado.Errors
            //     .Should()
            //     .BeEmpty("foi previamente cadastrado um cliente"); 
        }
    }
}