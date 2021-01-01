using FluentValidation.Results;
using SIS.Canil.Negocio.Conversor;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos;
using SIS.Canil.Negocio.Requisitos.Cao;

namespace SIS.Canil.Servicos.ServicosDeCaes
{
    public class LidarComAlteracaoDeCaes : ServicoBase, ISolicitacao<RequisitosParaAlterarCao>
    {
        private readonly IRepositorioDeCaes _repositorioDeCaes;

        public LidarComAlteracaoDeCaes(IRepositorioDeCaes repositorioDeCaes)
        {
            _repositorioDeCaes = repositorioDeCaes;
        }

        public ValidationResult LidarCom(RequisitosParaAlterarCao requisitos)
        {
            if (!requisitos.EValido())
                return requisitos.ResultadoDaValidacao;

            var oCaoExisteNaBaseDeDados = _repositorioDeCaes.Existe(requisitos.Id);
            if (!oCaoExisteNaBaseDeDados)
            {
                AdicionarErro("O cão não esta cadastrado na base de dados");
                return ResultadoDaValidacao;
            }

            var cao = requisitos.ConverterParaCao(requisitos.Id);
            var resultado = PersistirDados(() => _repositorioDeCaes.Inserir(cao));
            return resultado;
        }

    }
}