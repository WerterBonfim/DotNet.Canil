using System;
using FluentValidation.Results;
using MongoDB.Bson;

namespace SIS.Canil.Negocio.Requisitos
{
    public abstract class RequisitosBase : IRequisitos
    {
        public ValidationResult ResultadoDaValidacao { get; set; }

        public virtual bool EValido()
        {
            throw new NotImplementedException();
        }
        
        public static bool TerIdValido(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;
                
            return ObjectId.TryParse(id, out _);
        }
    }
}