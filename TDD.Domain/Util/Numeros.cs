namespace TDD.Dominio.Util
{
    using System.Collections.Generic;

    public class Numeros
    {
        public IEnumerable<int> ListarImpares(int limite)
        {
            for (var i = 0; i <= limite; i++)
                if (i % 2 != 0)
                    yield return i;
        }
    }
}
