namespace TDD.Domain.Servicos
{
    using System.Linq;
    using TDD.Domain.Entidades;
    using TDD.Domain.Interfaces;

    public class ReservaServico
    {
        private readonly IReservaRepositorio _repositorio;

        public ReservaServico(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool ExisteReservaQueSobrepoe(Reserva reserva)
        {
            var minhasReservas = _repositorio.ListarReservasAtivas();

            /*
                                     |---- Reserva A ----| 
|           |---- Reserva B ----|                          
            (Verdadeiro se DataDePartida A > DataDeChegada B)

            |---- Reserva A ----| 
|                                  |---- Reserva B ----|                          
            (Verdadeiro se DataDeChegada A < DataDePartida B)

            */

            return minhasReservas.Any(a =>
                 a.Id != reserva.Id &&
                 reserva.DataDePartida <= a.DataDeChegada &&
                 reserva.DataDeChegada >= a.DataDePartida);
        }
    }
}
