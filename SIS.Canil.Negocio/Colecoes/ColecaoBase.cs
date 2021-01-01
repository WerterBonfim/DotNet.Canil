using MongoDB.Bson;

namespace SIS.Canil.Negocio.Colecoes
{
    public abstract class ColecaoBase
    {
        public ObjectId Id { get; set; }

        public ColecaoBase(string id = null)
        {
            Id = string.IsNullOrEmpty(id) ? ObjectId.GenerateNewId() : ObjectId.Parse(id);
        }
    }
}