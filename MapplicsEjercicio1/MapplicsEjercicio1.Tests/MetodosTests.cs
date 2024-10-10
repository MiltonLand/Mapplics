using MapplicsEjercicio1Consola;
using Xunit;

namespace MapplicsEjercicio1.Tests
{
    public class MetodosTests
    {
        [Theory]
        [InlineData("Hola", "aloH")]
        [InlineData("Mundo", "odnuM")]
        [InlineData("", "")]
        public void InversionDePalabra_InvertirString(string s, string expected)
        {
            string actual = Metodos.InversionDePalabra(s);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hola", false)]
        [InlineData("neuQUen", true)]
        [InlineData("", false)]
        [InlineData("Anilina", true)]
        [InlineData("Tomate", false)]
        [InlineData("S", false)]
        [InlineData("AA", true)]
        [InlineData("aSA", true)]
        public void DeterminacionDeCapicua_EsCapicua(string s, bool expected)
        {
            bool actual = Metodos.DeterminacionDeCapicua(s);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hola", 2)]
        [InlineData("HOLA", 2)]
        [InlineData("TomatE", 3)]
        [InlineData("LechugA", 3)]
        [InlineData("VIdeo", 3)]
        [InlineData("", 0)]
        [InlineData("ES", 1)]
        [InlineData("aaaaAeeeiiasd", 11)]
        public void ContarVocales_CuentaVocales(string s, int expected)
        {
            int actual = Metodos.ContarVocales(s);

            Assert.Equal(expected, actual);
        }
    }
}
