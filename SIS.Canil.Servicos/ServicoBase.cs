using System;
using FluentValidation.Results;

namespace SIS.Canil.Servicos
{
    public abstract class ServicoBase
    {
        protected ValidationResult ResultadoDaValidacao;

        public ServicoBase()
        {
            ResultadoDaValidacao = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ResultadoDaValidacao.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
        
        protected void AdicionarErro(Exception exception)
        {
            if (exception != null && exception.InnerException == null)
            {
                ResultadoDaValidacao.Errors.Add(new ValidationFailure(string.Empty, exception.Message));
                return;
            }

            if (exception != null) AdicionarErro(exception.InnerException);
        }
        

        // protected async Task<ValidationResult> PersistirDados(object dados)
        // {
        //     var inseriu = await unitOfWork.Commit();
        //     if (!inseriu)
        //         AdicionarErro("Houve um erro ao persistir os dados");
        //
        //     return ValidationResult;
        // }
    }
}