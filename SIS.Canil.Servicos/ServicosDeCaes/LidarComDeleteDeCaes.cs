using FluentValidation.Results;
using MongoDB.Bson;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos.Cao;

namespace SIS.Canil.Servicos.ServicosDeCaes
{
    public class LidarComDeleteDeCaes : ServicoBase, ISolicitacao<RequisitosParaDeletarCao>
    {
        private readonly IRepositorioDeCaes _repositorioDeCaes;

        public LidarComDeleteDeCaes(IRepositorioDeCaes repositorioDeCaes)
        {
            _repositorioDeCaes = repositorioDeCaes;
        }

        public ValidationResult LidarCom(RequisitosParaDeletarCao requisitos)
        {
            if (!requisitos.EValido())
                return requisitos.ResultadoDaValidacao;

            var id = ObjectId.Parse(requisitos.Id);
            var resultado = PersistirDados(() => _repositorioDeCaes.Deletar(id));
            return resultado;
        }
    }
}