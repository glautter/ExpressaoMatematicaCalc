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
        private Numero Numero { get; set; } = new Numero();

        public OperacaoMatematica(string operacao)
        {
            Operacao = operacao;
        }

        public int Calcular()
        {
            var itensExpressaoMatematica = new List<object>();
            var numero = string.Empty;
            foreach (var caracter in Operacao)
            {
                if (EhNumerico(caracter))
                {
                    numero += caracter.ToString();
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(numero))
                    {
                        Numero.AtribuirValor(int.Parse(numero));
                        itensExpressaoMatematica.Add(Numero);
                    }
                    if (!string.IsNullOrWhiteSpace(caracter.ToString()) && Numero.)
                        itensExpressaoMatematica.Add(caracter.ToString());
                    

                    numero = string.Empty;
                }
            }

            return RealizarOperacao(itensExpressaoMatematica);
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

        private bool EhNumerico(char item)
        {
            return int.TryParse(item.ToString(), out int n);
        }
    }
}
