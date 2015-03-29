namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;

    public abstract class Villain : MovingObject, IMovable
    {
        protected Villain(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }
    }
}
