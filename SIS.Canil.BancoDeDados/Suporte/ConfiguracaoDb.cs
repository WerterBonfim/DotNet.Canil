namespace SIS.Canil.BancoDeDados.Suporte
{
    public static class ConfiguracaoDb
    {
        public static string Usuario { get; set; }
        public static string Senha { get; set; }
        public static string Host { get; set; }
        public static int Porta { get; set; }

        /// <summary>
        /// Banco usado para se autenticar
        /// </summary>
        public static string BancoAutenticancao { get; set; }

        public static string Banco { get; set; }
    }
}