using System;
using System.Linq;

namespace SIS.Canil.BancoDeDados.Suporte
{
    public static class ConfiguracaoDb
    {
        public static string Usuario { get; set; }
        public static string Senha { get; set; }
        public static string Host { get; set; }
        public static string Porta { get; set; }

        /// <summary>
        /// Banco usado para se autenticar
        /// </summary>
        public static string BancoAutenticancao { get; set; }

        public static string Banco { get; set; }

        public static bool EstaInvalida()
        {
            var itens = new string[]
            {
                Usuario,
                Senha,
                Host,
                Porta,
                Banco,
                BancoAutenticancao
            }.ToList();

            var algumItemNaoFoiPreechido = itens.Exists(string.IsNullOrEmpty);
            return algumItemNaoFoiPreechido;
        }
    }
}