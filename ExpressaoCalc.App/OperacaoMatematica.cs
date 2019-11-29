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
            foreach (var caracter in ToString())
            {
                AdicionarCaracterNumerico(caracter.ToString());
                if (!EhSinal(caracter) && !EhVazioOuNulo(caracter))
                {
                    AdicionarItensExpressaoNumerica(caracter.ToString());
                }
                else
                {
                    AdicionarItensExpressaoNumerica(Numero);
                    InicializarNumero();
                }
            }
            
            return RealizarOperacao(ItensExpressaoMatematica);
        }

        private void InicializarNumero()
        {
            Numero = new Numero();
        }

        private bool EhVazioOuNulo(char caracter)
        {
            return string.IsNullOrWhiteSpace(caracter.ToString());
        }

        private void AdicionarItensExpressaoNumerica(Numero numero)
        {
            if (!Numero.ValorZerado)
                ItensExpressaoMatematica.Add(numero);
        }

        private void AdicionarItensExpressaoNumerica(string caracter)
        {
            if (!Numero.EhNumerico(caracter) && Numero.Valor == 0)
            {
                ItensExpressaoMatematica.Add(caracter);
                AdicionarItensExpressaoNumerica(Numero);
                    }
        }

        private void AdicionarCaracterNumerico(string caracter)
        {
            if (Numero.EhNumerico(caracter))
                Numero.ConcatenarValor(caracter);
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

            return ((Numero)itensExpressaoMatematica[0]).Valor;
        }

        public override string ToString()
        {
            return Operacao.Insert(Operacao.Length, " ");
        }
    }
}
