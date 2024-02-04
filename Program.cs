using EstructuresAvançades;
using System.Runtime.CompilerServices;
using System.Text;

namespace EstructuresAvançades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MostarTitol("TAULA HASH");
            TaulaHash<String> taula = CrearTaulaHash();
            Console.WriteLine(taula);

            MostarTitol("ARBRE BINARI");
            ArbreBinari<String> arbre = CrearArbreBinari();
            Console.WriteLine(arbre);

        }
        public static TaulaHash<String> CrearTaulaHash()
        {
            throw new NotImplementedException();
        }

        private static ArbreBinari<String> CrearArbreBinari()
        {
            throw new NotImplementedException();
        }

        private static void MostarTitol(String titol)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(titol);
            sb.AppendLine("----");
            Console.WriteLine(sb.ToString());
        }

    }


}

