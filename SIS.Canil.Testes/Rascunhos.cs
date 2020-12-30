using System;
using SIS.Canil.Negocio.Colecoes;
using Xunit;
using Xunit.Abstractions;

namespace SIS.Canil.Testes
{
    public class Rascunhos
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Rascunhos(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestarInstanciaCliente()
        {
            var cliente = new Cliente();    
            _testOutputHelper.WriteLine(cliente.Id.ToString());
        }
    }
}