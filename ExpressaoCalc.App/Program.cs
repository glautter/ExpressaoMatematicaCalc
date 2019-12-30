using System;
using System.Text;

namespace ExpressaoCalc.App
{
    class Program
    {
        public static StringBuilder ExpressionNumerica { get; set; } = new StringBuilder();
        static void Main(string[] args)
        {
            string expressao = "3 * [(2 + 5 - 3) * (40 + 5)]";

            var expressaoMatematica = new ExpressaoNumerica(expressao);
            expressaoMatematica.Resolver();
            Console.WriteLine(expressaoMatematica.ImprimirExpressao.ToString());
            Console.ReadKey();
        }
    }
}
