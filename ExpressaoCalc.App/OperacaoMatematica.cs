using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExpressaoCalc.App
{
    public class OperacaoMatematica
    {
        private readonly string Operacao;
        private Operador Operador;
        private readonly List<object> ItensExpressaoNumerica = new List<object>();

        private Numero Numero { get; set; } = new Numero();

        public OperacaoMatematica(string operacao)
        {
            Operacao = operacao;
        }

        public int Calcular()
        {
            ConverterItensDaExpressaoNumericaNosTiposCorrespondentes();

            return RealizarOperacao(ItensExpressaoNumerica);
        }

        private bool PrimeiroCaraterEhOperador
        {
            get
            {
                var primeiroCaracter = SepararNumerosDeOperadores[0].ToString();
                return primeiroCaracter == Operador.Soma || primeiroCaracter == Operador.Subtracao
                    || primeiroCaracter == Operador.Divisao || primeiroCaracter == Operador.Multiplicacao;
            }
        }

        private bool EhOperador(string caracter)
        {
            return caracter == Operador.Soma || caracter == Operador.Subtracao
                || caracter == Operador.Divisao || caracter == Operador.Multiplicacao;

        }

        private void ConverterItensDaExpressaoNumericaNosTiposCorrespondentes()
        {
            if (PrimeiroCaraterEhOperador)
                PrepararItensExpressaoNumericaComplexa();
            else
                ConverterItensDaExpressaoNumerica();
        }

        private void ConverterItensDaExpressaoNumerica()
        {
            int index = 0;
            bool operadorMultiplo = false;
            string caracterParametro = string.Empty;

            foreach (var caracter in SepararNumerosDeOperadores)
            {
                if (index > 0 && EhOperador(SepararNumerosDeOperadores[index].ToString())
                    && EhOperador(SepararNumerosDeOperadores[index - 1].ToString()))
                    operadorMultiplo = true;

                caracterParametro += caracter.ToString();

                if (!operadorMultiplo)
                {
                    AdicionarItemNaExpressaoNumerica(Numero, caracterParametro);
                    InicializarNumero();
                    caracterParametro = string.Empty;
                }
                operadorMultiplo = false;

                index++;
            }
        }

        private void PrepararItensExpressaoNumericaComplexa()
        {
            var numeroComSinal = string.Empty;

            for (int index = 0; index < SepararNumerosDeOperadores.Count; index++)
            {
                if (IndiceZeroOuUm(index))
                {
                    numeroComSinal += SepararNumerosDeOperadores[index].ToString() == Operador.Subtracao ? Operador.Subtracao :
                    SepararNumerosDeOperadores[index].ToString() == Operador.Soma ? string.Empty : SepararNumerosDeOperadores[index].ToString();

                    if (!EhOperador(SepararNumerosDeOperadores[index].ToString()))
                        AdicionarItemNaExpressaoNumerica(Numero, numeroComSinal);
                }
                else
                {
                    AdicionarItemNaExpressaoNumerica(Numero, SepararNumerosDeOperadores[index].ToString());
                    InicializarNumero();
                }
            }
        }

        private static bool IndiceZeroOuUm(int index)
        {
            return index >= 0 && index <= 1;
        }

        private MatchCollection SepararNumerosDeOperadores
        {
            get { return Regex.Matches(Operacao, "(\\d*[0-9]|\\w*[\\+\\-\\/\\*])"); }
        }

        private void InicializarNumero()
        {
            Numero = new Numero();
        }

        private void AdicionarItemNaExpressaoNumerica(Numero numero, string caracter)
        {
            if (Numero.EhNumerico(caracter))
            {
                Numero.AtribuirValor(int.Parse(caracter));
                ItensExpressaoNumerica.Add(numero);
            }
            else
                ItensExpressaoNumerica.Add(caracter);
        }

        private int RealizarOperacao(List<object> itensExpressaoMatematica)
        {
            Operador = new Multiplicacao(itensExpressaoMatematica);
            Operador.Resolver();
            Operador = new Divisao(itensExpressaoMatematica);
            Operador.Resolver();
            Operador = new Subtracao(itensExpressaoMatematica);
            Operador.Resolver();
            Operador = new Soma(itensExpressaoMatematica);
            Operador.Resolver();

            return ((Numero)itensExpressaoMatematica[0]).Valor;
        }
    }
}
