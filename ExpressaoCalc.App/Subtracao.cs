using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Subtracao : Operador
    {
        public Subtracao(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            Indexador = itensExpressaoMatematica.IndexOf("-");
        }

        public override void Resolver()
        {
            if (Indexador > -1)
            {
                Numero numero1 = ObterNumeroAnteriorAoOperador;
                Numero numero2 = ObterNumeroPosteriorAoOperador;
                Numero numeroOperador = new Numero(numero1.Valor, numero2.Valor);
                Resultado = -Resultado;
            }
        }
    }
}
