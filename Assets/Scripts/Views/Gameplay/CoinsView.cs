using TMPro;
using UnityEngine;

namespace Sketchy.Gameplay
{
    public class CoinsView : MonoBehaviour
    {
        [Tooltip("Coinboard GameObject used to show the current number of coins")]
        [SerializeField]
        private GameObject coinboard;

        [Tooltip("Text used to display the current number of coins")]
        [SerializeField]
        private TextMeshProUGUI coinboardCoins;

        /// <summary>
        /// Sets the coins to be displayed on the coinboard
        /// </summary>
        /// <param name="coins">User's current number of coins</param>
        internal void SetCoins(float coins)
        {
            coinboardCoins.text = Mathf.RoundToInt(coins).ToString();
        }

        /// <summary>
        /// Sets whether or not the coinsboard is to be shown
        /// </summary>
        /// <param name="show">Whether or not to show the coinboard</param>
        internal void ShowCoinboard(bool show)
        {
            if(coinboard)
            {
                coinboard.SetActive(show);
            }
        }
    }
}