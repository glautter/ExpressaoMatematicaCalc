namespace ExpressaoCalc.App
{
    public class Chave : Agrupador
    {
        public override string AgrupadorAberto { get => "{"; }
        public override string AgrupadorFechado { get => "}"; }
    }
}
