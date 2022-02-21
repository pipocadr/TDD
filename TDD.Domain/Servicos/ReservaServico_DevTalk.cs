namespace TDD.Dominio.Servicos
{
    using TDD.Dominio.Interfaces;

    public class ReservaServico_DevTalk
    {
        private readonly IReservaRepositorio _repositorio;

        public ReservaServico_DevTalk(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
