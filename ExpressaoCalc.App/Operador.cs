using System.Collections.Generic;

namespace ExpressaoCalc.App
{
    public abstract class Operador
    {
        public string Adicao => "+";
        public string Subtracao => "-";
        public string Multiplicacao => "*";
        public string Divisao => "/";
        public int Indexador { get; set; } = -1;
        public int Resultado { get; set; } = 0;
        public Numero Numero { get; set; }
        public List<object> ItensExpressaoMatematica { get; set; } = new List<object>();
        public virtual void Resolver() { }
        public bool EhOperador(string operador)
        {
            return operador.Contains(Adicao) || operador.Contains(Subtracao) || operador.Contains(Multiplicacao) || operador.Contains(Divisao);
        }

        public Numero ObterNumeroAnteriorAoOperador
        {
            get { return (Numero)ItensExpressaoMatematica[Indexador - 1]; }
        }
        public Numero ObterNumeroPosteriorAoOperador
        {
            get { return (Numero)ItensExpressaoMatematica[Indexador + 1]; }
        }

        public void SubstituirExpressao(int valor)
        {
            int totalItens = ItensExpressaoMatematica.Count;

            for (int index = 0; index < totalItens; index++)
            {
                if (index == Indexador - 1)
                {
                    ItensExpressaoMatematica[index] = new Numero(valor);
                }
                else
                {
                    if ((index > Indexador - 1) && (index <= Indexador + 1))
                        ItensExpressaoMatematica.Remove(index);
                }
            }
        }
    }
}
