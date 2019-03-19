namespace TDD.Dominio.Testes
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using TDD.Domain.Entidades;
    using TDD.Domain.Interfaces;
    using TDD.Dominio.Servicos;

    [TestFixture]
    public class ReservaServicoTeste_Dojo
    {
        private ReservaServico_Dojo service;
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

            service = new ReservaServico_Dojo(mock.Object);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_DatasDentroDoPeriodo()
        {
            //Arrange
            var reserva = new Reserva()
            {
                DataDePartida = DateTime.Now.AddDays(1),
                DataDeChegada = DateTime.Now.AddDays(2),
                Id = Guid.NewGuid()
            };
            
            //Act
            bool result  = service.ExisteReservaQueSobrepoe(reserva);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_DataInicioDentroDoPeriodoEFimForaDoPeriodo()
        {
            //Arrange
            var reserva = new Reserva()
            {
                DataDePartida = DateTime.Now.AddDays(5),
                DataDeChegada = DateTime.Now.AddDays(12),
                Id = Guid.NewGuid()
            };
            
            //Act
            bool result = service.ExisteReservaQueSobrepoe(reserva);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_DataInicioForaDoPeriodoEFimDentroDoPeriodo()
        {
            //Arrange
            var reserva = new Reserva()
            {
                DataDePartida = DateTime.Now.AddDays(-10),
                DataDeChegada = DateTime.Now.AddDays(2),
                Id = Guid.NewGuid()
            };
            
            //Act
            bool result = service.ExisteReservaQueSobrepoe(reserva);
            
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_DataInicioEFimForaDoPeriodo()
        {
            //Arrange
            var reserva = new Reserva()
            {
                DataDePartida = DateTime.Now.AddDays(20),
                DataDeChegada = DateTime.Now.AddDays(30),
                Id = Guid.NewGuid()
            };
            
            //Act
            bool result = service.ExisteReservaQueSobrepoe(reserva);
            
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_DataInicioEFimEntreDoPeriodo()
        {
            //Arrange
            var reserva = new Reserva()
            {
                DataDePartida = DateTime.Now.AddDays(-10),
                DataDeChegada = DateTime.Now.AddDays(20),
                Id = Guid.NewGuid()
            };
            
            //Act
            bool result = service.ExisteReservaQueSobrepoe(reserva);
            
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_DataInicioEFimAntesDoPeriodo()
        {
            //Arrange
            var reserva = new Reserva()
            {
                DataDePartida = DateTime.Now.AddDays(-15),
                DataDeChegada = DateTime.Now.AddDays(-10),
                Id = Guid.NewGuid()
            };

            //Act
            bool result = service.ExisteReservaQueSobrepoe(reserva);
            
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReservaServico_ExisteReservaQueSobrepoe_ReservaJacadastrada()
        {
            //Arrange
            reservaRioDeJaneiro.DataDeChegada = DateTime.Now.AddDays(-10);

            //Act
            bool result = service.ExisteReservaQueSobrepoe(reservaRioDeJaneiro);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
