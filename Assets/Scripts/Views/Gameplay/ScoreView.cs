using TMPro;
using UnityEngine;

namespace Sketchy.Gameplay
{
    public class ScoreView : MonoBehaviour
    {
        [Tooltip("Scoreboard GameObject used to show the current score")]
        [SerializeField]
        private GameObject scoreboard;

        [Tooltip("Text used to display the current score")]
        [SerializeField]
        private TextMeshProUGUI scoreboardScore;

        /// <summary>
        /// Sets the score to be displayed on the scoreboard
        /// </summary>
        /// <param name="score">User's current score</param>
        internal void SetScore(float score)
        {
            scoreboardScore.text = Mathf.FloorToInt(score).ToString();
        }

        /// <summary>
        /// Sets whether or not the scoreboard should be shown
        /// </summary>
        /// <param name="show">Whether or not to show the scoreboard</param>
        internal void ShowScoreboard(bool show)
        {
            if(scoreboard)
            {
                scoreboard.gameObject.SetActive(show);
            }
        }
    }
}