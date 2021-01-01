using FluentAssertions;
using SIS.Canil.Servicos.ServicosDeCaes;
using Xunit;

namespace SIS.Canil.Testes.Requisitos
{
    public class RequisitosCaoTestes : TesteBase
    {

        [Fact(DisplayName = "Os requisitos para gerar um cão devem ser validos")]
        [Trait("Requisitos para", "Cadastrar cão")]
        public void OsRequisitosDevemSerValidos()
        {
            var requisitos = GerarUmCao();

            requisitos.EValido()
                .Should()
                .BeTrue("os dados foram passados corretamente");
        }
        
        [Fact(DisplayName = "Deve notificar um erro, cão com idade inválida")]
        [Trait("Requisitos para", "Cadastrar cão")]
        public void IdadeInvalidaParaUmCao()
        {
            var requisitos = GerarUmCao();

            requisitos.DataDeNascimento = requisitos.DataDeNascimento.AddYears(-30);

            requisitos.EValido()
                .Should()
                .BeFalse("a idade é inválida para um cão");
        }
    }
}