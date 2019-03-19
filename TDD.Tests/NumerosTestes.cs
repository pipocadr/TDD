namespace TDD.Dominio.Testes
{
    using NUnit.Framework;
    using TDD.Dominio.Util;
    using System.Linq;

    [TestFixture]
    public class NumerosTestes
    {
        [Test]
        public void ListarImpares_LimiteIgualCinco_DeveRetornarInteirosAteLimite()
        {
            /// Arrange
            var numeros = new Numeros();

            /// Act
            var resultado = numeros.ListarImpares(5);

            /// Assert
            Assert.That(resultado, Is.Not.Empty);
            Assert.That(resultado.Count(), Is.EqualTo(3));
            Assert.That(resultado, Is.EquivalentTo(new[] { 1, 3, 5 }));
            Assert.That(resultado, Is.Ordered);
            Assert.That(resultado, Is.Unique);
        }
    }
}
