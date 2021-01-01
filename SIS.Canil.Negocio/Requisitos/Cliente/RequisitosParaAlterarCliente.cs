using System;
using FluentValidation;
using MongoDB.Bson;

namespace SIS.Canil.Negocio.Requisitos.Cliente
{
    public class RequisitosParaAlterarCliente : RequisitosDoClienteBase
    {
        public string Id { get; set; }
        public RequisitosParaAlterarCliente(
            string id,
            string nome = null,
            string sexo = null,
            string rg = null,
            string cpf = null,
            DateTime dataNascimento = default,
            string endereço = null,
            string numeroCasa = null,
            string bairro = null,
            string municipio = null,
            string uf = null,
            string localização = null,
            string complemento = null,
            string estadoCivil = null,
            string nacionalidade = null,
            string whatsApp = null,
            string telefoneFixo = null,
            string celular = null,
            string facebook = null,
            string instagram = null,
            string observação = null
        )
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            RG = rg;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Nacionalidade = nacionalidade;
            WhatsApp = whatsApp;
            TelefoneFixo = telefoneFixo;
            Celular = celular;
            Facebook = facebook;
            Instagram = instagram;
            Observação = observação;
            Localização = localização;
            Endereço = endereço;
            NumeroCasa = numeroCasa;
            Complemento = complemento;
            Bairro = bairro;
            Municipio = municipio;
            UF = uf;
        }

        public override bool EValido()
        {
            if (!base.EValido())
                return false;

            ResultadoDaValidacao = new ValidacaoParaAtualizarClientes().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }
        
        private sealed class ValidacaoParaAtualizarClientes : AbstractValidator<RequisitosParaAlterarCliente>
        {
            public ValidacaoParaAtualizarClientes()
            {
                RuleFor(x => x.Id)
                    .Must(TerIdValido);
            }

            
        }
    }
}