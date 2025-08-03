using UnityEngine;

public class LimitFps : MonoBehaviour
{
    [SerializeField]
    private int targetFps = 144;
    private void Start()
    {
        Application.targetFrameRate = targetFps;
    }
}
