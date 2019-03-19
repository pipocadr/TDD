namespace TDD.Dominio.Util
{
    using System;
    using TDD.Dominio.Interfaces;

    public class Log
    {
        public string UltimoLog { get; set; }

        public event EventHandler<Guid> LogEvent;

        public void Salvar(string mensagem)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                throw new ArgumentNullException();

            UltimoLog = mensagem;

            LogEvent?.Invoke(this, Guid.NewGuid());
        }

        public void Salvar(ILogRepositorio repositorio, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
                throw new ArgumentNullException();

            repositorio.Salvar(mensagem);
        }
    }
}
