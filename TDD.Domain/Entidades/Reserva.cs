namespace TDD.Dominio.Entidades
{
    using System;

    public class Reserva
    {
        public Guid Id { get; set; }
        public DateTime DataDePartida { get; set; }
        public DateTime DataDeChegada { get; set; }
    }
}
