using SIS.Canil.Negocio.Colecoes;
using SIS.Canil.Negocio.Requisitos.Cliente;

namespace SIS.Canil.Negocio.Conversor
{
    public static class ClienteConversor
    {
        public static Cliente ConverterParaCliente(this RequisitosDoClienteBase requisitos, string id = null)
        {
            return new Cliente(
                requisitos.Nome,
                requisitos.Sexo,
                requisitos.EstadoCivil,
                requisitos.RG,
                requisitos.Cpf,
                requisitos.DataNascimento,
                requisitos.Nacionalidade,
                requisitos.WhatsApp,
                requisitos.TelefoneFixo,
                requisitos.Celular,
                requisitos.Facebook,
                requisitos.Instagram,
                requisitos.Observação,
                requisitos.Localização,
                requisitos.Endereço,
                requisitos.NumeroCasa,
                requisitos.Complemento,
                requisitos.Bairro,
                requisitos.Municipio,
                requisitos.UF,
                id
            );
        }
    }
}