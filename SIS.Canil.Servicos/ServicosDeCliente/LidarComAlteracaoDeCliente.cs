using System;
using FluentValidation.Results;
using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Conversor;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos.Cliente;

namespace SIS.Canil.Servicos.ServicosDeCliente
{
    public class LidarComAlteracaoDeCliente : ServicoBase, ISolicitacao<RequisitosParaAlterarCliente>
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;

        public LidarComAlteracaoDeCliente(IRepositorioDeClientes repositorioDeClientes)
        {
            _repositorioDeClientes = repositorioDeClientes;
        }
        
        public ValidationResult LidarCom(RequisitosParaAlterarCliente requisitos)
        {
            if (!requisitos.EValido())
                return ResultadoDaValidacao;

            var clienteExiste = _repositorioDeClientes.BuscarPorId(requisitos.Id);
            if (clienteExiste == null)
            {
                AdicionarErro("Cliente não existe na base de dados");
                return ResultadoDaValidacao;
            }

            var cliente = requisitos.ConverterParaCliente(requisitos.Id);
            AtualizarCliente(cliente);

            return ResultadoDaValidacao;
        }

        private void AtualizarCliente(Cliente cliente)
        {
            try
            {
                _repositorioDeClientes.Atualizar(cliente);
            }
            catch (Exception e)
            {
                AdicionarErro(e);
            }
            
        }
    }
}