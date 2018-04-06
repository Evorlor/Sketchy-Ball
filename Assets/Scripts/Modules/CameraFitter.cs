using UnityEngine;

namespace Sketchy.Modules
{
    public class CameraFitter : MonoBehaviour
    {
        private void Start()
        {
            StretchToFillCamera();
        }

        private void StretchToFillCamera()
        {
            float y = Camera.main.orthographicSize * 2.0f;
            float x = (float)Screen.width / Screen.height * y;
            float z = transform.localScale.z;
            transform.localScale = new Vector3(x, y, z);
        }
    }
}