namespace EasterFarm.Models.Presents
{
    using System;

    public class PresentFactory
    {
        public const string InvalidPresentTypeExcMsg = "The present you're trying to make does not yet exist in our world. Try again next Easter!";

        public Present Get(PresentType presentType)
        {
            switch (presentType)
            {
                case PresentType.Kozunak:
                    return new Present(PresentType.Kozunak, (int)PresentType.Kozunak, RecipeConstants.Recipes[PresentType.Kozunak]);
                case PresentType.ChocoEgg:
                    return new Present(PresentType.ChocoEgg, (int)PresentType.ChocoEgg, RecipeConstants.Recipes[PresentType.ChocoEgg]);
                case PresentType.Cookie:
                    return new Present(PresentType.Cookie, (int)PresentType.Cookie, RecipeConstants.Recipes[PresentType.Cookie]);
                case PresentType.ChocoRabbit:
                    return new Present(PresentType.ChocoRabbit, (int)PresentType.ChocoRabbit, RecipeConstants.Recipes[PresentType.ChocoRabbit]);
                case PresentType.RabbitWithRibbon:
                    return new Present(PresentType.RabbitWithRibbon, (int)PresentType.RabbitWithRibbon, RecipeConstants.Recipes[PresentType.RabbitWithRibbon]);
                default:
                    throw new InvalidOperationException(InvalidPresentTypeExcMsg);
            }
        }
    }
}
