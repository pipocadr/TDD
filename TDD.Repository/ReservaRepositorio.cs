namespace TDD.Repository
{
    using System.Collections.Generic;
    using TDD.Dominio.Entidades;
    using TDD.Dominio.Interfaces;

    public class ReservaRepositorio : IReservaRepositorio
    {
        public IList<Reserva> ListarReservasAtivas()
        {
            return new List<Reserva>();
        }
    }
}
