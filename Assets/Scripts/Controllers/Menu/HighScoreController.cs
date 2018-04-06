using Sketchy.Managers;
using UnityEngine;

namespace Sketchy.Menu
{
    [RequireComponent(typeof(HighScoreView))]
    public class HighScoreController : MonoBehaviour
    {
        [Tooltip("Data for player's high score")]
        [SerializeField]
        private HighScoreModel highScoreModel;

        private HighScoreView highScoreView;

        private void Awake()
        {
            highScoreView = GetComponent<HighScoreView>();
        }

        private void Start()
        {
            highScoreView.SetHighScore(GameManager.ScoreManager.GetHighScore());
        }
    }
}