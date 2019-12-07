using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExpressaoCalc.App
{
    public class OperacaoMatematica
    {
        private readonly string Operacao;
        private Operador Soma;
        private Operador Subtracao;
        private Operador Multiplicacao;
        private Operador Divisao;
        public readonly string SinalAberto;
        public readonly string SinalFechado;
        private readonly List<object> ItensExpressaoMatematica = new List<object>();

        private Numero Numero { get; set; } = new Numero();

        public OperacaoMatematica(string operacao)
        {
            Operacao = operacao;
        }

        public int Calcular()
        {
            CarregarItensDaExpressaoMatematica();

            return RealizarOperacao(ItensExpressaoMatematica);
        }

        private void CarregarItensDaExpressaoMatematica()
        {
            foreach (var caracter in SepararNumerosDeOperadores)
            {
                AdicionarItemNaExpressaoMatematica(Numero, caracter.ToString());
                InicializarNumero();
            }
        }

        private MatchCollection SepararNumerosDeOperadores
        {
            get { return Regex.Matches(Operacao, "(\\d*[0-9]|\\w*[\\+\\-\\/\\*])"); }
        }
        
        private void InicializarNumero()
        {
            Numero = new Numero();
        }
        
        private void AdicionarItemNaExpressaoMatematica(Numero numero, string caracter)
        {
            if (Numero.EhNumerico(caracter))
            {
                Numero.AtribuirValor(int.Parse(caracter));
                ItensExpressaoMatematica.Add(numero);
            }
            else
                ItensExpressaoMatematica.Add(caracter);
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
    }
}
