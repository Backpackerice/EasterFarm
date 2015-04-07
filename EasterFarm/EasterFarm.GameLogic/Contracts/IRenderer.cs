namespace EasterFarm.GameLogic.Contracts
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.Presents;
    using System.Collections.Generic;

    public interface IRenderer
    {
        void EnqueueForRendering(IRenderable obj);

        void RenderAll();

        void RenderPresentFactory(IDictionary<IStorable, int> presents);

        void RenderMarket(ICollection<IBuyable> proucts);

        void ClearRenderer();
    }
}
