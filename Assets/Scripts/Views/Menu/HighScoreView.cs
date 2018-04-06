using TMPro;
using UnityEngine;

namespace Sketchy.Menu
{
    public class HighScoreView : MonoBehaviour
    {
        [Tooltip("Text used to display the user's high score")]
        [SerializeField]
        private TextMeshProUGUI scoreboard;

        /// <summary>
        /// Sets the high score for the user
        /// </summary>
        /// <param name="highScore">User's high score</param>
        internal void SetHighScore(float highScore)
        {
            scoreboard.text = Mathf.FloorToInt(highScore).ToString();
        }
    }
}