namespace EasterFarm.Models.PresentFactory
{
    public class PresentConstructor
    {
        public void Construct(PresentBuilder presentBuilder)
        {
            presentBuilder.AddEggs();
            presentBuilder.AddFlour();
            presentBuilder.AddCocoa();
            presentBuilder.AddMilk();
            presentBuilder.AddRibbon();
            presentBuilder.SetType();
            presentBuilder.SetValue();
            presentBuilder.SetCurrency();
        }
    }
}
