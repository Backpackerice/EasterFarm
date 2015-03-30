namespace EasterFarm.Models.MarketPlace
{
    using EasterFarm.Models.Contracts;

    public class Ingredient : Product, ICookable, IBuyable, IStorable
    {
        public Ingredient(IngredientType type, int price)
            : base(type, Category.Ingredient, price)
        {
        }
    }
}
