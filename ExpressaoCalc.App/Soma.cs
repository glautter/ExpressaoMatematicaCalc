using System.Collections.Generic;

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
                Numero = ObterNumerosAnteriorEPosterior;
                Numero = +Numero;
                SubstituirExpressao(Numero.Valor);

                InicializarPosicaoOperador();
                ObterPosicaoOperador(Soma);
            }
        }
    }
}
