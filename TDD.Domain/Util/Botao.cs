namespace TDD.Dominio.Util
{
    public class Botao
    {
        private IDispositivo _lampada;

        public void Acionar()
        {
            _lampada.Ligar();
        }
    }

    public class Lampada : IDispositivo
    {
        public void Ligar() { /* Implementação */ }

        public void Desligar() { /* Implementação */ }
    }

    public interface IDispositivo
    {
        void Ligar();
        void Desligar();
    }
}
