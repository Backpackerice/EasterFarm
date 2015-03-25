namespace EasterFarm.Models.PresentFactory.Presents
{
    using EasterFarm.Models.Market;

    public class ChocoRabbit : Present
    {
        private const int EggsAmmount = 2;
        private const int FlourAmmount = 1;
        private const int CocoaAmmount = 3;
        private const int MilkAmmount = 1;
        private const int BasketAmmount = 1;
        private const int RabbitAmmount = 1;

        public ChocoRabbit(FarmManager producer)
            : base(PresentType.ChocoRabbit, (int)PresentType.ChocoRabbit, MarketCurrency.Raspberries, producer)
        {
        }

        public override void SetIngredients()
        {
            this.NeededIngredients.Add(IngredientType.Egg, EggsAmmount);
            this.NeededIngredients.Add(IngredientType.Flour, FlourAmmount);
            this.NeededIngredients.Add(IngredientType.Cocoa, CocoaAmmount);
            this.NeededIngredients.Add(IngredientType.Milk, MilkAmmount);
            this.NeededIngredients.Add(IngredientType.Basket, BasketAmmount);
            this.NeededIngredients.Add(IngredientType.Rabbit, RabbitAmmount);
        }
    }
}
