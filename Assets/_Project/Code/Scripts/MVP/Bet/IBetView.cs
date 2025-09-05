using UnityEngine.UI;

namespace Project.Game
{
    public interface IBetView
    {
        Button ButtonUp { get; }
        Button ButtonDown { get; }
        void UpdateText(string text);
        void Destroy();
    }
}