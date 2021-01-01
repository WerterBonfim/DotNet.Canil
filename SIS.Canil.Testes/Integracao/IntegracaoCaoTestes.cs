using System.Linq;
using FluentAssertions;
using FluentValidation.Results;
using SIS.Canil.Negocio.Conversor;
using SIS.Canil.Negocio.Requisitos.Cao;
using SIS.Canil.Servicos.ServicosDeCaes;
using Xunit;

namespace SIS.Canil.Testes.Integracao
{
    public class IntegracaoCaoTestes : TesteBase
    {
        [Fact(DisplayName = "Deve cadastrar um cão com sucesso")]
        [Trait("Cão", "Cadastro")]
        public void DeveCadastrarUmCao()
        {
            var requisitosParaCadastrarCao = GerarUmCao();
            var serviço = new LidarComCriacaoDeCaes(RepositorioDeCaes);
            var resultado = serviço.LidarCom(requisitosParaCadastrarCao);

            resultado.Errors
                .Should()
                .BeEmpty("todos os dados foram passado corretamente");
        }
        
        [Fact(DisplayName = "Deve altera um cão com sucesso")]
        [Trait("Cão", "Alterar")]
        public void DeveAlterarUmCao()
        {
            var requisitosNovoCao = GerarUmCao();
            var cao = RepositorioDeCaes.Listar()
                .FirstOrDefault();

            cao.Should()
                .NotBeNull("foi cadastrado previamente um cão");
            
            var requisitosParaAlterar = new RequisitosParaAlterarCao(
                cao.Id.ToString(),
                // Alterando o nome
                "TDD",
                // Alterando o dia de nascimento
                cao.DataDeNascimento.AddDays(1),
                cao.Sexo,
                cao.CorDoAnimal,
                cao.Pedgree,
                cao.Observacoes
            );

            var servico = new LidarComAlteracaoDeCaes(RepositorioDeCaes);
            
            var resultado = servico.LidarCom(requisitosParaAlterar);

            

        }

        private void CadastrarUmNovoCao(RequisitosParaCadastrarCao requisitos)
        {
            var serviço = new LidarComCriacaoDeCaes(RepositorioDeCaes);
            var resultado = serviço.LidarCom(requisitos);
        }
    }
}