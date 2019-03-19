namespace TDD.Dominio.Servicos
{
    using System.Linq;
    using TDD.Domain.Entidades;
    using TDD.Domain.Interfaces;

    public class ReservaServico_Dojo
    {
        private readonly IReservaRepositorio _repositorio;

        public ReservaServico_Dojo(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool ExisteReservaQueSobrepoe(Reserva reserva)
        {
            bool retorno;
            retorno = false;

            foreach (var item in _repositorio.ListarReservasAtivas().Where( r=> r.Id != reserva.Id))
            {
                if (item.DataDeChegada >= reserva.DataDeChegada && item.DataDePartida <= reserva.DataDePartida)
                    retorno = true;

                else if ((item.DataDeChegada <= reserva.DataDeChegada && item.DataDeChegada >= reserva.DataDePartida) && item.DataDeChegada < reserva.DataDeChegada)
                    retorno = true;

                else if ((item.DataDePartida >= reserva.DataDePartida && item.DataDePartida <= reserva.DataDeChegada) && item.DataDeChegada > reserva.DataDeChegada)
                    retorno = true;

                else if (item.DataDeChegada < reserva.DataDeChegada && item.DataDePartida < reserva.DataDeChegada)
                    retorno = false;

                else if (item.DataDeChegada > reserva.DataDePartida && item.DataDePartida > reserva.DataDePartida)
                    retorno = false;

                else if (item.DataDeChegada < reserva.DataDeChegada && item.DataDePartida > reserva.DataDePartida)
                    retorno = true;
            }

            return retorno;
        }
    }
}
