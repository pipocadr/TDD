namespace TDD.Dominio.Interfaces
{
    using TDD.Dominio.Entidades;

    public interface IAprovacaoRepositorio
    {
        bool JanelaAberta();
        void Aprovar(Pedido pedido);
    }
}
