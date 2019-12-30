using System.Collections.Generic;

namespace ExpressaoCalc.App
{
    public class Divisao : Operador
    {
        public Divisao(List<object> itensExpressaoMatematica)
        {
            ItensExpressaoMatematica = itensExpressaoMatematica;
            ObterPosicaoOperador(Divisao);
        }

        public override void Resolver()
        {
            while (PosicaoOperador > -1)
            {
                Numero = ObterNumerosAnteriorEPosterior;
                Numero /= Numero;
                SubstituirExpressao(Numero.Valor);

                InicializarPosicaoOperador();
                ObterPosicaoOperador(Divisao);
            }
        }
    }
}
