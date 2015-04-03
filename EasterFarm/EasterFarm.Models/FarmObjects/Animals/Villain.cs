namespace EasterFarm.Models.FarmObjects.Animals
{
    public abstract class Villain : Animal
    {
        protected Villain(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }
    }
}
