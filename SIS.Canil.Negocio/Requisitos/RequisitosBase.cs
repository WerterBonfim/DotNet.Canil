using System;
using FluentValidation.Results;

namespace SIS.Canil.Negocio.Requisitos
{
    public abstract class RequisitosBase : IRequisitos
    {
        public RequisitosBase()
        {
            TimeStamp = DateTime.Now;
        }

        public DateTime TimeStamp { get; }
        public ValidationResult ResultadoDaValidacao { get; set; }

        public virtual bool EValido()
        {
            throw new NotImplementedException();
        }
    }
}