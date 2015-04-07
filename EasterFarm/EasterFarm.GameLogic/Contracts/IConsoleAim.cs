namespace EasterFarm.GameLogic.Contracts
{
    using EasterFarm.Models.Contracts;

    public interface IConsoleAim : IRenderable
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
