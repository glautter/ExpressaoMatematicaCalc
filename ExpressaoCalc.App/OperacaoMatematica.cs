using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    public class OperacaoMatematica
    {
        private readonly string Operacao;
        private Operador Soma;
        private Operador Subtracao;
        private Operador Multiplicacao;
        private Operador Divisao;
        private readonly string SinalAberto;
        private readonly string SinalFechado;
        private readonly List<object> ItensExpressaoMatematica = new List<object>();
        private Numero Numero { get; set; } = new Numero();

        public OperacaoMatematica(string operacao, string sinalAberto, string sinalFechado)
        {
            Operacao = operacao;
            SinalAberto = sinalAberto;
            SinalFechado = sinalFechado;
        }

        public int Calcular()
        {

            foreach (var caracter in Operacao)
            {
                AdicionarCaracterNumerico(caracter);
                if (!EhSinal(caracter) && EstaVazioOuNulo(caracter))
                {
                    AdicionarItensExpressaoNumerica(caracter.ToString());
                    AdicionarItensExpressaoNumerica(Numero);
                }
            }

            return RealizarOperacao(ItensExpressaoMatematica);
        }

        private bool EstaVazioOuNulo(char caracter)
        {
            return string.IsNullOrWhiteSpace(caracter.ToString());
        }

        private void AdicionarItensExpressaoNumerica(Numero numero)
        {
            ItensExpressaoMatematica.Add(numero);
        }

        private void AdicionarItensExpressaoNumerica(string caracter)
        {
            ItensExpressaoMatematica.Add(caracter);
        }

        private void AdicionarCaracterNumerico(char caracter)
        {
            Numero.ConcatenarValor(caracter.ToString());
        }

        private bool EhSinal(char caracter)
        {
            return caracter.ToString().Equals(SinalAberto) || caracter.ToString().Equals(SinalFechado);
        }

        private int RealizarOperacao(List<object> itensExpressaoMatematica)
        {
            Multiplicacao = new Multiplicacao(itensExpressaoMatematica);
            Multiplicacao.Resolver();
            Divisao = new Divisao(itensExpressaoMatematica);
            Divisao.Resolver();
            Subtracao = new Subtracao(itensExpressaoMatematica);
            Subtracao.Resolver();
            Soma = new Soma(itensExpressaoMatematica);
            Soma.Resolver();

            return Soma.Resultado;
        }
    }
}
