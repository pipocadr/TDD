namespace TDD.Dominio.Servicos
{
    using System;
    using TDD.Dominio.Entidades;
    using TDD.Dominio.Interfaces;

    public class AprovacaoServico
    {
        private readonly IAprovacaoRepositorio _repositorio;

        public AprovacaoServico(IAprovacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void AprovarPedido(Pedido pedido)
        {
            if (_repositorio.JanelaAberta())
            {
                if (pedido.Status.Equals(StatusPedido.PendenteAprovacao))
                {
                    _repositorio.Aprovar(pedido);
                }
            }
            else throw new Exception("Janela fechada para aprovação de pedidos!");
        }
    }
}
