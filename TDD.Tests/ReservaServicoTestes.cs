namespace TDD.Dominio.Testes
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using TDD.Domain.Entidades;
    using TDD.Domain.Interfaces;
    using TDD.Domain.Servicos;

    [TestFixture]
    public class ReservaServicoTeste
    {
        private ReservaServico service;
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

            service = new ReservaServico(mock.Object);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaComecaTerminaAntesDeOutraReserva_RetornaFalso()
        {
            /// Arrange
            var novaReserva = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = AntesDe(reservaRioDeJaneiro.DataDePartida, dias: 10),
                DataDeChegada = AntesDe(reservaRioDeJaneiro.DataDePartida, dias: 1)
            };

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(novaReserva);

            /// Assert
            Assert.That(resultado, Is.False);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaComecaAntesTerminaNoMeioDeOutraReserva_RetornaVerdadeiro()
        {
            /// Arrange
            var novaReserva = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = AntesDe(reservaRioDeJaneiro.DataDePartida, dias: 3),
                DataDeChegada = DepoisDe(reservaRioDeJaneiro.DataDePartida, dias: 3)
            };

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(novaReserva);

            /// Assert
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaComecaTerminaNoMeioDeOutraReserva_RetornaVerdadeiro()
        {
            /// Arrange
            var novaReserva = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = DepoisDe(reservaRioDeJaneiro.DataDePartida, dias: 1),
                DataDeChegada = AntesDe(reservaRioDeJaneiro.DataDeChegada, dias: 1)
            };

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(novaReserva);

            /// Assert
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaComecaNoMeioTerminaDepoisDeOutraReserva_RetornaVerdadeiro()
        {
            /// Arrange
            var novaReserva = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = DepoisDe(reservaRioDeJaneiro.DataDePartida, dias: 1),
                DataDeChegada = DepoisDe(reservaRioDeJaneiro.DataDeChegada, dias: 1)
            };

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(novaReserva);

            /// Assert
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaComecaTerminaDepoisDeOutraReserva_RetornaFalso()
        {
            /// Arrange
            var novaReserva = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = DepoisDe(reservaRioDeJaneiro.DataDeChegada, dias: 1),
                DataDeChegada = DepoisDe(reservaRioDeJaneiro.DataDeChegada, dias: 5)
            };

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(novaReserva);

            /// Assert
            Assert.That(resultado, Is.False);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaComecaAntesTerminaDepoisDeOutraReserva_RetornaVerdadeiro()
        {
            /// Arrange
            var novaReserva = new Reserva()
            {
                Id = Guid.NewGuid(),
                DataDePartida = AntesDe(reservaRioDeJaneiro.DataDePartida, dias: 3),
                DataDeChegada = DepoisDe(reservaRioDeJaneiro.DataDeChegada, dias: 3)
            };

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(novaReserva);

            /// Assert
            Assert.That(resultado, Is.True);
        }

        [Test]
        public void ExisteReservaQueSobrepoe_ReservaEditadaNaoSobrepoe_RetornaFalso()
        {
            /// Arrange
            reservaRioDeJaneiro.DataDePartida = DepoisDe(reservaRioDeJaneiro.DataDePartida, dias: 1);

            /// Act
            var resultado = service.ExisteReservaQueSobrepoe(reservaRioDeJaneiro);

            /// Assert
            Assert.That(resultado, Is.False);
        }

        private DateTime AntesDe(DateTime data, int dias)
        {
            return data.AddDays(-dias);
        }

        private DateTime DepoisDe(DateTime data, int dias)
        {
            return data.AddDays(dias);
        }
    }
}