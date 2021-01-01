using System;
using FluentValidation.Results;
using SIS.Canil.Negocio.Conversor;
using SIS.Canil.Negocio.Repositorio;
using SIS.Canil.Negocio.Requisitos.Cao;

namespace SIS.Canil.Servicos.ServicosDeCaes
{
    public class LidarComCriacaoDeCaes : ServicoBase, ISolicitacao<RequisitosParaCadastrarCao>
    {
        private readonly IRepositorioDeCaes _repositorioDeCaes;

        public LidarComCriacaoDeCaes(IRepositorioDeCaes repositorioDeCaes)
        {
            _repositorioDeCaes = repositorioDeCaes;
        }

        public ValidationResult LidarCom(RequisitosParaCadastrarCao requisitos)
        {
            if (!requisitos.EValido())
                return requisitos.ResultadoDaValidacao;

            var cao = requisitos.ConverterParaCao();

            var resultado = PersistirDados(() =>
            {
                Console.WriteLine("Vou executar a ação 2");
                _repositorioDeCaes.Inserir(cao);
            });
            return resultado;
        }
    }
}