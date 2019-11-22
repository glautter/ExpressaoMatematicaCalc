using System;
using ExpressaoCalc.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressaoCalc.Test
{
    [TestClass]
    public class CalculoExpressaoTest
    {
        private readonly string ExpressaoSoComParenteses = "3 * (2 + 5)";
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
        public void DeveResolverAExpressao()
        {
            ExpressaoMatematica = new ExpressaoNumerica(ExpressaoSoComParenteses);
            Assert.IsFalse(ExpressaoMatematica.Parentese.Resolver(ExpressaoSoComParenteses).Equals(ExpressaoSoComParenteses));
        }
    }
}
