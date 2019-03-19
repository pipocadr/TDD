namespace TDD.Dominio.Testes
{
    using NUnit.Framework;
    using TDD.Dominio.Util;

    [TestFixture]
    public class FormatadorDeMensagemTeste
    {
        [Test]
        public void FormatarEmNegrito_QuandoExecutado_DeveEncapsularTextoComElementoDeNegrito()
        {
            /// Arrange
            var formatador = new FormatadorDeMensagem();

            var titutlo = "Gustavo";

            /// Act
            var resultado = formatador.FormatarEmNegrito(titutlo);

            /// Assertivo Específico
            Assert.That(resultado, Is.EqualTo("<strong>Gustavo</strong>").IgnoreCase);

            /// Assertivo Genérico
            Assert.That(resultado, Does.StartWith("<strong>"));
            Assert.That(resultado, Does.EndWith("</strong>"));
            Assert.That(resultado, Does.Contain("Gustavo"));
        }
    }
}
