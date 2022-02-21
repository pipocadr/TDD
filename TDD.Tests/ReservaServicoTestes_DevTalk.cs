namespace TDD.Dominio.Testes
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using TDD.Dominio.Entidades;
    using TDD.Dominio.Interfaces;
    using TDD.Dominio.Servicos;

    [TestFixture]
    public class ReservaServicoTestes_DevTalk
    {
        private ReservaServico_DevTalk service;
        private Mock<IReservaRepositorio> mock;
        private Reserva reservaRioDeJaneiro;

        [SetUp]
        public void SetUp()
        {
            reservaRioDeJaneiro = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = DateTime.Now.AddDays(-7),
                DataDeChegada = DateTime.Now.AddDays(7)
            };

            mock = new Mock<IReservaRepositorio>();

            mock.Setup(m => m.ListarReservasAtivas()).Returns(new List<Reserva>() { reservaRioDeJaneiro });

            service = new ReservaServico_DevTalk(mock.Object);
        }

        [Test]
        public void Teste_1()
        {
            /// Arrange

            /// Act

            /// Assert
        }
    }
}
