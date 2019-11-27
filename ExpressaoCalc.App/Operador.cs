using System.Collections.Generic;

namespace ExpressaoCalc.App
{
    public abstract class Operador
    {
        public string Soma => "+";
        public string Subtracao => "-";
        public string Multiplicacao => "*";
        public string Divisao => "/";
        public int PosicaoOperador { get; set; } = -1;
        public int Resultado { get; set; } = 0;
        public Numero Numero { get; set; }
        public List<object> ItensExpressaoMatematica { get; set; } = new List<object>();
        public virtual void Resolver() { }

        public bool EhOperador(string operador)
        {
            return operador.Contains(Soma) || operador.Contains(Subtracao) || operador.Contains(Multiplicacao) || operador.Contains(Divisao);
        }

        public Numero ObterNumeroAnteriorAoOperador
        {
            get { return (Numero)ItensExpressaoMatematica[PosicaoOperador - 1]; }
        }

        public Numero ObterNumeroPosteriorAoOperador
        {
            get { return (Numero)ItensExpressaoMatematica[PosicaoOperador + 1]; }
        }

        public void ObterPosicaoOperador(string operacao)
        {
            PosicaoOperador = ItensExpressaoMatematica.IndexOf(operacao);
        }

        public void InicializarPosicaoOperador()
        {
            PosicaoOperador = -1;
        }

        public void SubstituirExpressao(int valor)
        {
            int totalItens = ItensExpressaoMatematica.Count;

            for (int index = 0; index < totalItens; index++)
            {
                if (index == PosicaoOperador - 1)
                {
                    AdicionarItemDeSubstituicao(valor, index);
                    RemoverItemDaExpressaoResolvido(PosicaoOperador);
                }
            }
        }

        private void AdicionarItemDeSubstituicao(int valor, int index)
        {
            ItensExpressaoMatematica[index] = new Numero(valor);
        }

        private void RemoverItemDaExpressaoResolvido(int index)
        {
            ItensExpressaoMatematica.RemoveRange(index, 2);
        }
    }
}
