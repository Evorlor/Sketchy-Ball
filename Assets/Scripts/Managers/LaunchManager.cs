using Sketchy.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchManager : MonoBehaviour
{
    [Tooltip("Whether or not to show the navigation bar at the bottom of the screen (in Android)")]
    [SerializeField]
    private bool showNavigationBar = true;

#if UNITY_ANDROID
    private void Awake()
    {
        Screen.fullScreen = !showNavigationBar;
    }
#endif

    private void Start()
    {
        SceneManager.LoadScene(SceneNames.Main);
    }
}