using System;
using ExpressaoCalc.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressaoCalc.Test
{
    [TestClass]
    public class CalculoExpressaoTest
    {
        private readonly string ExpressaoSoComParenteses = "3 * (2 + 5)";
        private readonly string ExpressaoSoComDoisParenteses = "3 * ((2 + 5) + 5)";
        private readonly string ExpressaoSoComTresParenteses = "8 / {1 + [3 * (4 * (45 + 90)) + (8 - 5)] * 5}";
        private readonly string ExpressaoSoComParentesesSemEspaco = "3*(2+5)";
        private ExpressaoNumerica ExpressaoMatematica { get; set; }
        

        [TestMethod]
        public void DeveObterParenteseAberto()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.SinalAberto == "(");
        }

        [TestMethod]
        public void DeveObterParenteseFechado()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.SinalFechado == ")");
        }

        [TestMethod]
        public void DeveIdentificarSeTemSinal()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            ExpressaoMatematica.Parentese.AdicionarExpressao(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.Parentese.TemSinal);
        }

        [TestMethod]
        public void DeveRetirarOsEspacos()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            Assert.IsTrue(ExpressaoMatematica.RetirarEspacos(ExpressaoSoComParenteses) == ExpressaoSoComParentesesSemEspaco);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "3 * 7") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsDoisParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComDoisParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "3 * 12") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoComResultado21()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 21") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressao()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParentesesSemEspaco);
            var resultado = ExpressaoMatematica.Resolver();
            Assert.IsTrue(String.Compare(resultado, "-> 21") == 0);
        }

        [TestMethod]
        public void DeveResolverAExpressaoEliminandoOsTresParenteses()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComTresParenteses);
            Assert.IsTrue(String.Compare(ExpressaoMatematica.Parentese.Resolver(), "8 / {1 + [3 * 540 + 3] * 5}") == 0);
        }
    }
}
