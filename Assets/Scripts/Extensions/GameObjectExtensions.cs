using UnityEngine;

namespace Sketchy.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets the extents of a GameObject based on its Collider2D and Renderer (if applicable)
        /// </summary>
        /// <param name="gameObject">GameObject to get the extents of</param>
        /// <returns>The extents of the GameObject</returns>
        public static Vector3 GetExtents(this GameObject gameObject)
        {
            var collider = gameObject.GetComponent<Collider2D>();
            var renderer = gameObject.GetComponent<Renderer>();
            var colliderSize = collider ? collider.bounds.extents : Vector3.zero;
            var rendererSize = renderer ? renderer.bounds.extents : Vector3.zero;
            return Vector3.Max(colliderSize, rendererSize);
        }
    }
}