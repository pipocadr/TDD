namespace TDD.Dominio.Testes
{
    using Moq;
    using NUnit.Framework;
    using System;
    using TDD.Dominio.Interfaces;
    using TDD.Dominio.Util;

    [TestFixture]
    public class LogTestes
    {
        [Test]
        public void Salvar_QuandoExecutado_DefiniPropriedadeUltimoLog()
        {
            /// Arrange
            var log = new Log();

            var mensagem = "Teste";

            /// Act
            log.Salvar(mensagem);

            /// Assert
            Assert.That(log.UltimoLog, Is.EqualTo(mensagem));
        }

        [Test]
        public void Salvar_QuandoExecutado_ExecutarUmaUnicaVezChamadaNoRepositorio()
        {
            /// Arrange
            var log = new Log();

            var mock = new Mock<ILogRepositorio>();

            var mensagem = "Teste";

            /// Act
            log.Salvar(mock.Object, mensagem);

            /// Assert
            mock.Verify(m => m.Salvar(mensagem), times: Times.Once);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Salvar_MensagemInvalida_SubirExcecao(string mensagem)
        {
            /// Arrange
            var log = new Log();

            /// Act & Assert
            Assert.That(() => log.Salvar(mensagem), Throws.ArgumentNullException);

            /// Outro Exemplo:
            Assert.That(() => log.Salvar(mensagem), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Salvar_MensagemValida_AcionarEventoDeLog()
        {
            /// Arrange
            var log = new Log();

            /// Act
            var id = Guid.Empty;

            log.LogEvent += (sender, args) => { id = args; };

            var mensagem = "Teste";

            log.Salvar(mensagem);

            /// Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
