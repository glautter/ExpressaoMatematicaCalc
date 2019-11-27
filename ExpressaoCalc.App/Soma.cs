using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class Soma : Operador
    {
        public Soma(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            ObterPosicaoOperador(Soma);
        }

        public override void Resolver()
        {
            while (PosicaoOperador > -1)
            {
                Numero numeroAnterior = ObterNumeroAnteriorAoOperador;
                Numero numeroPosterior = ObterNumeroPosteriorAoOperador;
                Numero = new Numero(numeroAnterior.Valor, numeroPosterior.Valor);
                Numero = +Numero;
                SubstituirExpressao(Numero.Valor);
                InicializarPosicaoOperador();
                ObterPosicaoOperador(Soma);
            }
        }
    }
}
