namespace TDD.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;

    public class Pedido
    {
        public Guid Id { get; set; }
        public StatusPedido Status { get; set; }
        public List<string> Itens { get; set; }
        public decimal Valor { get; set; }
    }

    public enum StatusPedido
    {
        PendenteAprovacao,
        Aprovado,
        Cancelado
    }
}
