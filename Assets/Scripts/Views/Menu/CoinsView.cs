using TMPro;
using UnityEngine;

namespace Sketchy.Menu
{
    public class CoinsView : MonoBehaviour
    {
        [Tooltip("Text used to display the user's total coins")]
        [SerializeField]
        private TextMeshProUGUI coins;

        [Tooltip("Text used to display the user's total coins achieved ever")]
        [SerializeField]
        private TextMeshProUGUI lifetimeCoins;

        /// <summary>
        /// Sets the number of coins the user currently has to be displayed
        /// </summary>
        /// <param name="coins">User's current coin count</param>
        internal void SetCoins(float coins)
        {
            this.coins.text = Mathf.RoundToInt(coins).ToString();
        }

        /// <summary>
        /// Sets the text for the number of coins the user has achieved ever
        /// </summary>
        /// <param name="lifetimeCoins">User's lifetime coin count</param>
        internal void SetLifetimeCoins(float lifetimeCoins)
        {
            this.lifetimeCoins.text = Mathf.RoundToInt(lifetimeCoins).ToString();
        }
    }
}