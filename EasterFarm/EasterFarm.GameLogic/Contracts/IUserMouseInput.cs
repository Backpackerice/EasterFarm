namespace EasterFarm.GameLogic.Contracts
{
    using System;

    public interface IUserMouseInput : IUserInput
    {
        event EventHandler OnMouseLeftPressed;
    }
}
