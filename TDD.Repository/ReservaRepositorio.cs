namespace TDD.Repository
{
    using System.Collections.Generic;
    using TDD.Domain.Entidades;
    using TDD.Domain.Interfaces;

    public class ReservaRepositorio : IReservaRepositorio
    {
        public IList<Reserva> ListarReservasAtivas()
        {
            return new List<Reserva>();
        }
    }
}
