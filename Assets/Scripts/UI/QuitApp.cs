using UnityEngine;

public class QuitApp : MonoBehaviour
{
    public void Quit()
    {
        // If we are running in the editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If we are running in a build, quit the application
        Application.Quit();
        #endif
    }
}
