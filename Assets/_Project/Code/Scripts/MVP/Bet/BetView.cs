using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Game
{
    public class BetView : MonoBehaviour, IBetView
    {
        [SerializeField] private TMP_Text _text;
        [field: SerializeField] public Button ButtonUp { get; private set; }
        [field: SerializeField] public Button ButtonDown { get; private set; }

        public void UpdateText(string text)
        {
            _text.SetText(text);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}