using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using SIS.Canil.Negocio.Requisitos.Cliente;
using Xunit;

namespace SIS.Canil.Testes.Requisitos
{
    
    public class ClientesTestes
    {
        
        [Fact(DisplayName = "Registrando um cliente")]
        [Trait("Requisitos para", "Criar")]
        public void DeveCadastrarUmClienteComSucesso()
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

            cliente.EValido().Should().BeTrue(
                "Porquê todos os dados foram preenchido corretamente pela" +
                "biblioteca Bogus");
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
    }
}