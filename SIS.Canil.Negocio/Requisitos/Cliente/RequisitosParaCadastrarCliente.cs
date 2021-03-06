using System;
using FluentValidation;

namespace SIS.Canil.Negocio.Requisitos.Cliente
{
    public class RequisitosParaCadastrarCliente : RequisitosDoClienteBase
    {
        public RequisitosParaCadastrarCliente(
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

        public RequisitosParaCadastrarCliente()
        {
        }
        
        
        
    }
}