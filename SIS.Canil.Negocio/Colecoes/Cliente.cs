using System;

namespace SIS.Canil.Negocio.Colecoes
{
    public class Cliente : ColecaoBase
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
            string uf = null,
            string id = null
        ) : base(id)
        {
            Nome = nome;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            RG = rg;

            if (!string.IsNullOrEmpty(cpf))
                Cpf = cpf
                    .Replace(".", "")
                    .Replace("-", "");
            
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

        public Cliente()
        {
        }

        public string Nome { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }
        public string RG { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Nacionalidade { get; private set; }
        public string WhatsApp { get; private set; }
        public string TelefoneFixo { get; private set; }
        public string Celular { get; private set; }
        public string Facebook { get; private set; }
        public string Instagram { get; private set; }
        public string Observação { get; private set; }
        public string Localização { get; private set; }
        public string Endereço { get; private set; }
        public string NumeroCasa { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string UF { get; private set; }

        public override string ToString()
        {
            return $"{Nome}, {Cpf}";
        }
    }
}