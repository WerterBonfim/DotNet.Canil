using System;
using FluentValidation;

namespace SIS.Canil.Negocio.Requisitos.Cliente
{
    public abstract class RequisitosDoClienteBase : RequisitosBase
    {
        protected RequisitosDoClienteBase(
            string nome = null,
            string sexo = null,
            string rg = null,
            string cpf = null,
            string email = null ,
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

        public RequisitosDoClienteBase()
        {
        }

        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string RG { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public string Email { get; set; }
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

        public override bool EValido()
        {
            ResultadoDaValidacao = new ValidacaoParaRegistrarUmCliente().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }

        private sealed class ValidacaoParaRegistrarUmCliente : AbstractValidator<RequisitosDoClienteBase>
        {
            public ValidacaoParaRegistrarUmCliente()
            {
               

                When(c => !string.IsNullOrEmpty(c.Cpf), () =>
                {
                    RuleFor(x => x.Cpf)
                        .Must(TerCpfValido)
                        .WithMessage("O CPF informado não é válido.");
                });

                When(c => c.DataNascimento != default, () =>
                {
                    RuleFor(x => x.DataNascimento)
                        .GreaterThan(new DateTime(1900, 1, 1))
                        .WithMessage("Data informada é inválida");
                });
                
                // TODO: Implementar validação de email.
                // When(c => !string.IsNullOrEmpty(c.Email), () =>
                // {
                //     RuleFor(x => x.Email)
                //         .Must(TerEmailValido)
                //         .WithMessage("O e-mail informado não é valido.");    
                // });
            }

            private static bool TerCpfValido(string cpf)
            {
                return Utils.CPF.EValido(cpf);
            }

            // private static bool TerEmailValido(string email)
            // {
            //     return Utils.Email.Validar(email);
            // }
        }
    }
}