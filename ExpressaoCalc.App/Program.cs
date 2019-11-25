using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressaoCalc.App
{
    class Program
    {
        public static StringBuilder ExpressionNumerica { get; set; } = new StringBuilder();
        static void Main(string[] args)
        {
            string expressao = "3 * (2 + 5 - 3) * (40 + 5)";

            var expressaoMatematica = new ExpressaoNumerica(expressao);
            var resultado = expressaoMatematica.Resolver();

            Console.ReadKey();
        }
    }
}
