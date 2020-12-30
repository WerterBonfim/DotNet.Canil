using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SIS.Canil.Negocio.Utils;

namespace SIS.Canil.Negocio.Colecoes
{
    public class Cliente
    {
        public Cliente(
            string nome = null,
            string sexo = null,
            string estadoCivil = null,
            string rg = null,
            string cpf = null,
            DateTime dataNascimento = default,
            string nacionalidade = null,
            string whatsApp = null,
            string telefoneFixo = null,
            string celular = null,
            string facebook = null,
            string instagram = null,
            string observação = null,
            string localização = null,
            string endereço = null,
            string numeroCasa = null,
            string complemento = null,
            string bairro = null,
            string municipio = null,
            string uf = null
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

            Id = ObjectId.GenerateNewId();
        }

        public Cliente()
        {
            Id = ObjectId.GenerateNewId();
        }

        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string RG { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string WhatsApp { get; set; }
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Observação { get; set; }
        public string Localização { get; set; }
        public string Endereço { get; set; }
        public string NumeroCasa { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
    }
}