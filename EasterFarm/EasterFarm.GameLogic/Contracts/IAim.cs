namespace EasterFarm.GameLogic.Contracts
{
    using EasterFarm.Models.Contracts;

    public interface IAim : IRenderable
    {
        void MoveUp();

        void MoveDown();

        void MoveLeft();

        void MoveRight();

        int Size { get; }
    }
}
