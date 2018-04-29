using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    public abstract class Collectable : MonoBehaviour
    {
        /// <summary>
        /// Event called when the collectable has been collected
        /// </summary>
        internal static UnityAction<Collectable> OnCollected;

        [Tooltip("The score this collectable is worth")]
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        protected float score = 0.0f;

        [Tooltip("The coins this collectable is worth")]
        [SerializeField]
        [Range(0.0f, 100.0f)]
        protected float coins = 0.0f;

        protected virtual void OnTriggerEnter2D(Collider2D collider2D)
        {
            Collect();
        }

        /// <summary>
        /// Gets the score this collectable is worth
        /// </summary>
        /// <returns>Score gained for collecting</returns>
        internal float GetScoreCollected()
        {
            return score;
        }

        /// <summary>
        /// Gets the coins this collectable is worth
        /// </summary>
        /// <returns>Coins gained for collecting</returns>
        internal float GetCoinsCollected()
        {
            return coins;
        }

        protected virtual void Collect()
        {
            if (OnCollected != null)
            {
                OnCollected(this);
            }
            Destroy(gameObject);
        }
    }
}