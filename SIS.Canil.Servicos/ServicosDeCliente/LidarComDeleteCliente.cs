using FluentValidation.Results;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos.Cliente;

namespace SIS.Canil.Servicos.ServicosDeCliente
{
    public class LidarComDeleteCliente : ServicoBase, ISolicitacao<RequisitosParaDeletarCliente>
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;

        public LidarComDeleteCliente(IRepositorioDeClientes repositorioDeClientes)
        {
            _repositorioDeClientes = repositorioDeClientes;
        }

        public ValidationResult LidarCom(RequisitosParaDeletarCliente requisitos)
        {
            if (!requisitos.EValido())
                return ResultadoDaValidacao;

            _repositorioDeClientes.Deletar(requisitos.Id);
            return ResultadoDaValidacao;
        }
    }
}