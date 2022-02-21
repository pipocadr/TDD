namespace TDD.Dominio.Interfaces
{
    using System.Collections.Generic;
    using TDD.Dominio.Entidades;

    public interface IReservaRepositorio
    {
        IList<Reserva> ListarReservasAtivas();
    }
}
