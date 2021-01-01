using System.Linq;
using FluentAssertions;
using SIS.Canil.Negocio.Colecoes;
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
            CadastrarUmNovoCao(requisitosNovoCao);
            
            var cao = RepositorioDeCaes.Listar()
                .FirstOrDefault();

            cao.Should()
                .NotBeNull("foi cadastrado previamente um cão");

            var novaDataDeNascimento = cao.DataDeNascimento.AddDays(1);
            var requisitosParaAlterar = new RequisitosParaAlterarCao(
                cao.Id.ToString(),
                // Alterando o nome
                "TDD",
                // Alterando o dia de nascimento
                novaDataDeNascimento,
                cao.Sexo,
                cao.CorDoAnimal,
                cao.Pedgree,
                cao.Observacoes
            );

            var servico = new LidarComAlteracaoDeCaes(RepositorioDeCaes);
            
            var resultado = servico.LidarCom(requisitosParaAlterar);

            resultado.Errors
                .Should()
                .BeEmpty("todo so dados foram preenchidos");

            var recemAlterado = RepositorioDeCaes.BuscarPorId(cao.Id);

            recemAlterado.Nome
                .Should()
                .BeEquivalentTo("TDD");

            recemAlterado.DataDeNascimento
                .Should()
                .BeSameDateAs(novaDataDeNascimento);


        }

        private void CadastrarUmNovoCao(RequisitosParaCadastrarCao requisitos)
        {
            var serviço = new LidarComCriacaoDeCaes(RepositorioDeCaes);
            var resultado = serviço.LidarCom(requisitos);
        }

        [Fact(DisplayName = "Deve excluir um cão com sucesso")]
        [Trait("Cão", "Deletar")]
        public void DeveExcluirUmCao()
        {
            var novoCao = GerarUmCao();
            CadastrarUmNovoCao(novoCao);

            var cao = ObterUmCaoDoBancoDeDados();
            var requisitosDelete = new RequisitosParaDeletarCao(cao.Id.ToString());
            var servico = new LidarComDeleteDeCaes(RepositorioDeCaes);
            var resultado = servico.LidarCom(requisitosDelete);

            resultado
                .Errors
                .Should()
                .BeEmpty("foi cadastrad um cão previamente e foi fornecido um id para deletar");
        }

        private Cao ObterUmCaoDoBancoDeDados()
        {
            var cao = RepositorioDeCaes.Listar()
                .FirstOrDefault();
            
            return cao;
        }
    }
}