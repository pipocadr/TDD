namespace TDD.Dominio.Testes
{
    using NUnit.Framework;
    using TDD.WebApi.Controllers;

    [TestFixture]
    public class ValuesControllerTestes
    {
        [SetUp]
        /// Unit Test Runner irá chamar este método ANTES de cada teste
        public void SetUp()
        {

        }

        [TearDown]
        /// Unit Test Runner irá chamar este método DEPOIS de cada teste
        /// Utilizado geralmente para testes de integração
        public void TearDown()
        {

        }

        [Test]
        public void Get_IdIgualZero_RetornaNotFound()
        {
            /// Arrange
            var controller = new ValuesController();

            /// Act
            var resultado = controller.Get(0);

            /// Assert
            /// Objeto NotFound
            Assert.That(resultado, Is.TypeOf<NotFound>());

            /// Objeto ou alguma derivada de NotFound
            Assert.That(resultado, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void Get_IdDiferenteDeZero_RetornaOK()
        {
            /// Arrange
            var controller = new ValuesController();

            /// Act
            var resultado = controller.Get(1);

            /// Assert
            Assert.That(resultado, Is.TypeOf<OK>());
        }
    }
}
