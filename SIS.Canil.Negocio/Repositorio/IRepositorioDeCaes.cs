using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using SIS.Canil.Negocio.Colecoes;

namespace SIS.Canil.Negocio.Repositorio
{
    public interface IRepositorioDeCaes 
    {
        void Inserir(Cao cao);
        void Atualizar(Cao cao);
        void Deletar(ObjectId id);
        Cao BuscarPorId(string id);
        Cao BuscarPorId(ObjectId id);
        IList<Cao> Listar(Func<Cao, bool> filtro = null,  int pagina = 0, int qtdPorPagina = 10);
        bool Existe(string id);
    }
}