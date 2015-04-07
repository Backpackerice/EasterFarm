namespace EasterFarm.GameLogic.Contracts
{
    using EasterFarm.Models.Contracts;

    public interface IAim : IRenderable
    {
        int Size { get; }

        void MoveUp();

        void MoveDown();

        void MoveLeft();

        void MoveRight();
    }
}
