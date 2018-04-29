using UnityEngine;

namespace Sketchy.Modules
{
    public class DestroyedOnBecameInvisible : MonoBehaviour
    {
        [Tooltip("How long of a delay until destroyed after becoming invisible")]
        [SerializeField]
        [Range(0.0f, 5.0f)]
        private float delay = 0.0f;

        private void OnBecameInvisible()
        {
            Destroy(gameObject, delay);
        }
    }
}