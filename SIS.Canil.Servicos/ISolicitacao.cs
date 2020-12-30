using FluentValidation.Results;
using SIS.Canil.Negocio.Requisitos;

namespace SIS.Canil.Servicos
{
    public interface ISolicitacao<T> where T : IRequisitos
    {
        ValidationResult LidarCom(T requisitos);
    }
}