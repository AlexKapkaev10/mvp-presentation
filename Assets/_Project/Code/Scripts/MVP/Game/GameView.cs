using UnityEngine;
using UnityEngine.UI;

namespace Project.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        [field: SerializeField] public Button PlayButton { get; private set; }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}