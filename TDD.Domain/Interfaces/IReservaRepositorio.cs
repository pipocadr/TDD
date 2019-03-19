namespace TDD.Domain.Interfaces
{
    using System.Collections.Generic;
    using TDD.Domain.Entidades;

    public interface IReservaRepositorio
    {
        IList<Reserva> ListarReservasAtivas();
    }
}
