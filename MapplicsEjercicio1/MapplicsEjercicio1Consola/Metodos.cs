 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio1Consola
{
    public class Metodos
    {
        public static string InversionDePalabra(string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }
        public static bool DeterminacionDeCapicua(string s)
        {
            if (s.Length < 2)
            {
                return false;
            }

            var palabraInvertida = InversionDePalabra(s);

            return palabraInvertida.ToLower() == s.ToLower();
        }
        public static int ContarVocales(string s)
        {
            var sLower = s.ToLower();
            var vocales = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var contador = 0;

            for (int i = 0; i < sLower.Length; i++)
            {
                if (vocales.Contains(sLower[i]))
                {
                    contador++;
                }
            }

            return contador;
        }
    }
}
