using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    [RequireComponent(typeof(PlayerView))]
    [RequireComponent(typeof(Rigidbody2D))]
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
        private Rigidbody2D body2D;
        private PlayerController playerClone;
        private bool clone = false;

        private void Awake()
        {
            playerView = GetComponent<PlayerView>();
            body2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.GetComponent<Walls>() && !clone)
            {
                bool rightSideClone = transform.position.x < 0.0f;
                CreateClone(rightSideClone);
            }
        }

        private void OnTriggerStay2D(Collider2D collider2D)
        {
            if (collider2D.GetComponent<Walls>() && !clone)
            {
                ForceCloneToMimic();
                float xScreenExtent = (float)Screen.width / Screen.height * Camera.main.orthographicSize;
                if (transform.position.x < -xScreenExtent || transform.position.x > xScreenExtent)
                {
                    SwapClones();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.GetComponent<Walls>())
            {
                playerClone = null;
            }
        }

        private void OnBecameInvisible()
        {
            if (!clone && OnPlayerDied != null)
            {
                OnPlayerDied();
            }
        }

        private void CreateClone(bool rightSideClone)
        {
            playerClone = Instantiate(this, GetClonePosition(rightSideClone), Quaternion.identity, transform.parent);
            playerClone.clone = true;
        }

        private void ForceCloneToMimic()
        {
            bool rightSideClone = transform.position.x < playerClone.transform.position.x;
            var clonePosition = GetClonePosition(rightSideClone);
            playerClone.transform.position = clonePosition;
            playerClone.transform.rotation = transform.rotation;
        }

        private void SwapClones()
        {
            clone = true;
            playerClone.clone = false;
            playerClone.body2D.angularVelocity = body2D.angularVelocity;
            playerClone.body2D.velocity = body2D.velocity;
            playerClone.playerClone = this;
            playerClone = null;
        }

        private Vector2 GetClonePosition(bool rightSideClone)
        {
            float x = transform.position.x;
            float screenWidth = (float)Screen.width / Screen.height * Camera.main.orthographicSize * 2.0f;
            if (rightSideClone)
            {
                x += screenWidth;
            }
            else
            {
                x -= screenWidth;
            }
            float y = transform.position.y;
            return new Vector2(x, y);
        }
    }
}