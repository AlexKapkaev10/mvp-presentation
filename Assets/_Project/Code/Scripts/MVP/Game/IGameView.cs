using UnityEngine.UI;

namespace Project.Game
{
    public interface IGameView : IView
    {
        Button PlayButton { get; }
    }
}