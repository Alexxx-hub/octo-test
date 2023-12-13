using _Project.Scripts.Infrastructure;
using UnityEngine;
using Naninovel;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;

        private void OnEnable()
        {
            _homeButton.onClick.AddListener(StartNovelMode);
        }

        private void OnDisable()
        {
            _homeButton.onClick.RemoveListener(StartNovelMode);
        }

        private void StartNovelMode()
        {
            var miniGame = Engine.GetService<MiniGameService>();
            miniGame.LoadNovelGame();
        }
    }
}