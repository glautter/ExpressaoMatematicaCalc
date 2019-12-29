using System.Collections.Generic;

namespace ExpressaoCalc.App
{
    public abstract class Operador
    {
        public static string Soma => "+";
        public static string Subtracao => "-";
        public static string Multiplicacao => "*";
        public static string Divisao => "/";
        public int PosicaoOperador { get; set; } = -1;
        public int Resultado { get; set; } = 0;
        public Numero Numero { get; set; } = new Numero();
        public List<object> ItensExpressaoMatematica { get; set; } = new List<object>();
        public virtual void Resolver() { }

        public bool EhOperador(string operador)
        {
            return operador.Contains(Soma) || operador.Contains(Subtracao) || operador.Contains(Multiplicacao) || operador.Contains(Divisao);
        }

        public Numero NumeroAnteriorAoOperador
        {
            get
            {
                if (PosicaoOperador == 0 && EhOperador(ItensExpressaoMatematica[PosicaoOperador].ToString()))
                {
                    Numero.Valor = int.Parse(string.Join("", ItensExpressaoMatematica[PosicaoOperador], ((Numero)ItensExpressaoMatematica[PosicaoOperador + 1]).Valor.ToString()));
                    ReorganizarItensExpressaoMatematica();

                    return Numero;
                }

                return (Numero)ItensExpressaoMatematica[PosicaoOperador - 1];
            }
        }

        private void ReorganizarItensExpressaoMatematica()
        {
            for (int index = 0; index < ItensExpressaoMatematica.Count - 1; index++)
                ItensExpressaoMatematica[index] = index == 0 ? Numero : ItensExpressaoMatematica[index + 1];

            ItensExpressaoMatematica.RemoveAt(ItensExpressaoMatematica.Count - 1);
        }

        public Numero NumeroPosteriorAoOperador => (PosicaoOperador == 0 && EhOperador(ItensExpressaoMatematica[PosicaoOperador].ToString())) || ItensExpressaoMatematica.Count == 1 ? new Numero(0) : (Numero)ItensExpressaoMatematica[PosicaoOperador + 1];

        public void ObterPosicaoOperador(string operacao) => PosicaoOperador = ItensExpressaoMatematica.IndexOf(operacao);

        public void InicializarPosicaoOperador() => PosicaoOperador = -1;

        public void SubstituirExpressao(int valor)
        {
            int totalItens = ItensExpressaoMatematica.Count;

            for (int index = 0; index < totalItens; index++)
            {
                if (index == PosicaoOperador - 1)
                {
                    AdicionarItemDeSubstituicao(valor, index);
                    RemoverItemDaExpressaoCalculada(PosicaoOperador);
                }
            }
        }

        public Numero ObterNumerosAnteriorEPosterior => new Numero(NumeroAnteriorAoOperador.Valor, NumeroPosteriorAoOperador.Valor);

        private void AdicionarItemDeSubstituicao(int valor, int index) => ItensExpressaoMatematica[index] = new Numero(valor);
        private void RemoverItemDaExpressaoCalculada(int index) => ItensExpressaoMatematica.RemoveRange(index, 2);
    }
}
