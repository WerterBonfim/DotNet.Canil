using System;
using FluentValidation.Results;

namespace SIS.Canil.Servicos
{
    public abstract class ServicoBase
    {
        protected readonly ValidationResult ResultadoDaValidacao;

        protected ServicoBase()
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
        

        protected ValidationResult PersistirDados(Action acao)
        {
            try
            {
                Console.WriteLine("Vou executar a ação 1");
                acao();
            }
            catch (Exception e)
            {
                AdicionarErro("Houve um erro ao persistir os dados");
                AdicionarErro(e);
            }

            return ResultadoDaValidacao;
        }
    }
}