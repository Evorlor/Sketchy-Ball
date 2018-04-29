using Sketchy.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sketchy.Managers
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// The ScoreManager for the game
        /// </summary>
        internal static ScoreManager ScoreManager { get; private set; }

        /// <summary>
        /// The coin manager for the game
        /// </summary>
        internal static CoinsManager CoinsManager { get; private set; }

        private void OnEnable()
        {
            GameplayManager.OnGameStarted += StartGame;
            GameplayManager.OnGameOver += LoadMenu;
            GameplayManager.OnGameFinished += FinishGame;
        }

        private void Start()
        {
            ScoreManager = new ScoreManager();
            CoinsManager = new CoinsManager();
            SceneManager.LoadSceneAsync(SceneNames.Gameplay, LoadSceneMode.Additive);
            SceneManager.LoadScene(SceneNames.Menu, LoadSceneMode.Additive);
        }

#if UNITY_ANDROID
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
#endif

        private void OnDisable()
        {
            GameplayManager.OnGameStarted -= StartGame;
            GameplayManager.OnGameOver -= LoadMenu;
            GameplayManager.OnGameFinished -= FinishGame;
        }

        private void OnApplicationQuit()
        {
            Destroy(this);
        }

        private void StartGame()
        {
            SceneManager.UnloadSceneAsync(SceneNames.Menu);
        }

        private void FinishGame()
        {
            SceneManager.UnloadSceneAsync(SceneNames.Gameplay);
            SceneManager.LoadScene(SceneNames.Gameplay, LoadSceneMode.Additive);
        }

        private void LoadMenu()
        {
            SceneManager.LoadScene(SceneNames.Menu, LoadSceneMode.Additive);
        }
    }
}