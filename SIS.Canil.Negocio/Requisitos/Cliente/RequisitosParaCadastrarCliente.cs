using System;
using FluentValidation;

namespace SIS.Canil.Negocio.Requisitos.Cliente
{
    public class RequisitosParaCadastrarCliente : RequisitosBase
    {
        public RequisitosParaCadastrarCliente(
            string nome,
            string sexo,
            string rg,
            string cpf,
            DateTime dataNascimento,
            string endereço,
            string numeroCasa,
            string bairro,
            string municipio,
            string uf,
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

        public override bool EValido()
        {
            ResultadoDaValidacao = new ValidacaoParaRegistrarUmCliente().Validate(this);
            return ResultadoDaValidacao.IsValid;
        }

        private sealed class ValidacaoParaRegistrarUmCliente : AbstractValidator<RequisitosParaCadastrarCliente>
        {
            public ValidacaoParaRegistrarUmCliente()
            {
                RuleFor(x => x.Nome)
                    .NotEmpty()
                    .WithMessage("Nome é um campo obrigatório");

                RuleFor(x => x.Sexo)
                    .NotEmpty()
                    .WithMessage("Sexo é um campo obrigatório");
                
                RuleFor(x => x.RG)
                    .NotEmpty()
                    .WithMessage("RG é um campo obrigatório");
                
                RuleFor(x => x.Cpf)
                    .Must(TerCpfValido)
                    .WithMessage("O CPF informado não é válido.");
                
                RuleFor(x => x.DataNascimento)
                    .NotNull()
                    .WithMessage("Data é um campo obrigatório")
                    .GreaterThan(new DateTime(1900, 1, 1))
                    .WithMessage("Data informada é inválida");
                
                RuleFor(x => x.Endereço)
                    .NotEmpty()
                    .WithMessage("Endereço é um campo obrigatório");
                
                RuleFor(x => x.NumeroCasa)
                    .NotEmpty()
                    .WithMessage("NumeroCasa é um campo obrigatório");
                
                RuleFor(x => x.Bairro)
                    .NotEmpty()
                    .WithMessage("Bairro é um campo obrigatório");
                
                RuleFor(x => x.Municipio)
                    .NotEmpty()
                    .WithMessage("Municipio é um campo obrigatório");
                
                RuleFor(x => x.UF)
                    .NotEmpty()
                    .WithMessage("UF é um campo obrigatório");
                
                
                
                

                // RuleFor(x => x.Email)
                //     .Must(TerEmailValido)
                //     .WithMessage("O e-mail informado não é valido.");
            }
            
            private static bool TerCpfValido(string cpf)
            {
                return Utils.CPF.EValido(cpf);
            }
            
            // private static bool TerEmailValido(string email)
            // {
            //     return Core.DomainObjects.Email.Validar(email);
            // }
        }
    }
}