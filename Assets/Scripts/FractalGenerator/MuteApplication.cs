using UnityEngine;
using UnityEngine.UI;

public class MuteApplication : MonoBehaviour
{
    private bool isMuted = false;
    public Sprite muteIcon;
    public Sprite unmuteIcon;
    public Image muteButtonImage;

    public void Start()
    {
        muteButtonImage.sprite = unmuteIcon;
    }
    
    public void MuteApp()
    {
        if (!isMuted)
        {
            AudioListener.volume = 0f;
            isMuted = true;
            muteButtonImage.sprite = muteIcon;
        }
        else
        {
            AudioListener.volume = 1f;
            isMuted = false;
            muteButtonImage.sprite = unmuteIcon;
        }
    }

}
