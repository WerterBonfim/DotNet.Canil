using System;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using SIS.Canil.Negocio.Requisitos.Cliente;
using Xunit;

namespace SIS.Canil.Testes.Requisitos
{
    
    public class RequisitosClienteTestes : TesteBase
    {
        
        [Fact(DisplayName = "Registrando um cliente")]
        [Trait("Requisitos para", "Criar")]
        public void DeveCadastrarUmClienteComSucesso()
        {
            var cliente = GerarUmCliente();

            cliente.EValido().Should().BeTrue(
                "Porquê todos os dados foram preenchido corretamente pela" +
                "biblioteca Bogus");
        }
        
        [Fact(DisplayName = "Data de nascimento inválida")]
        [Trait("Requisitos para", "Criar")]
        public void DeveNotificarUmErroClienteComDataDeNascimentoInvalida()
        {
            var cliente = GerarUmCliente();
            cliente.DataNascimento = new DateTime(1800, 1, 1);

            cliente.EValido().Should().BeFalse(
                "a data de nascimento está inválida" );
        }
    }
}