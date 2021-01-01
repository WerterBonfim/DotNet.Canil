using System;
using FluentValidation.Results;
using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos.Cliente;


namespace SIS.Canil.Servicos.ServicosDeCliente
{
    public class LidarComCriacaoDeCliente : ServicoBase, ISolicitacao<RequisitosParaCadastrarCliente>
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;

        public LidarComCriacaoDeCliente(IRepositorioDeClientes repositorioDeClientes)
        {
            _repositorioDeClientes = repositorioDeClientes;
        }

        public ValidationResult LidarCom(RequisitosParaCadastrarCliente requisitos)
        {
            if (!requisitos.EValido())
                return requisitos.ResultadoDaValidacao;

            if (ClienteJaExiste(requisitos))
                return ResultadoDaValidacao;

            var cliente = new Cliente(
                requisitos.Nome,
                requisitos.Sexo,
                requisitos.EstadoCivil,
                requisitos.RG,
                requisitos.Cpf,
                requisitos.DataNascimento,
                requisitos.Nacionalidade,
                requisitos.WhatsApp,
                requisitos.TelefoneFixo,
                requisitos.Celular,
                requisitos.Facebook,
                requisitos.Instagram,
                requisitos.Observação,
                requisitos.Localização,
                requisitos.Endereço,
                requisitos.NumeroCasa,
                requisitos.Complemento,
                requisitos.Bairro,
                requisitos.Municipio,
                requisitos.UF
            );

            PersistirDados(cliente);
            return ResultadoDaValidacao;
        }

        private bool ClienteJaExiste(RequisitosParaCadastrarCliente requisitos)
        {
            if (requisitos.Cpf == null)
                return false;

            var clienteExiste = _repositorioDeClientes.BuscarPorCpf(requisitos.Cpf);
            if (clienteExiste != null)
            {
                AdicionarErro("Este CPF já está em uso");
                return true;
            }

            return false;
        }

        private void PersistirDados(Cliente cliente)
        {
            try
            {
                _repositorioDeClientes.Inserir(cliente);
            }
            catch (Exception e)
            {
                AdicionarErro(e);
            }
        }
    }
}