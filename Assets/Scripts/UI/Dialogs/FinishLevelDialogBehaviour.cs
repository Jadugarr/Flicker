using System;
using UnityEngine;
using UnityEngine.UI;

namespace SemoGames.UI
{
    public class FinishLevelDialogBehaviour : MonoBehaviour
    {
        [SerializeField] private Button restartLevelButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button quitGameButton;

        private void Awake()
        {
            restartLevelButton.onClick.AddListener(OnRestartClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuClicked);
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            quitGameButton.onClick.AddListener(OnQuitGameClicked);
        }

        private void Start()
        {
            nextLevelButton.Select();
        }

        private void OnDestroy()
        {
            restartLevelButton.onClick.RemoveListener(OnRestartClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuClicked);
            nextLevelButton.onClick.RemoveListener(OnNextLevelClicked);
            quitGameButton.onClick.RemoveListener(OnQuitGameClicked);
        }

        private void OnQuitGameClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnNextLevelClicked()
        {
            Debug.Log("Next Level!");
        }

        private void OnMainMenuClicked()
        {
            Debug.Log("Back to Main Menu!");
        }

        private void OnRestartClicked()
        {
            Debug.Log("Restart the level!");
        }
    }
}