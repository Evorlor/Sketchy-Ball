using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    [RequireComponent(typeof(PlayerView))]
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// Event triggered when the player dies
        /// </summary>
        internal static UnityAction OnPlayerDied;

        [Tooltip("Data for the player")]
        [SerializeField]
        private PlayerModel playerModel;

        private PlayerView playerView;

        private void Awake()
        {
            playerView = GetComponent<PlayerView>();
        }

        private void OnBecameInvisible()
        {
            if (OnPlayerDied != null)
            {
                OnPlayerDied();
            }
        }
    }
}