using DG.Tweening;
using TMPro;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    public GameObject bottomUI;
    public float animTime = 0.5f;
    public TextMeshProUGUI HideUIText;
    public string hideText = "▼";
    public string showText = "▲";

    private bool isHidden = false;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = bottomUI.transform.position;
    }

    public void Hide()
    {
        isHidden = !isHidden;
        float targetY = isHidden ? transform.position.y - 500f : initialPosition.y;
        bottomUI.transform.DOMoveY(targetY, animTime).SetEase(Ease.InOutQuad);
        HideUIText.text = isHidden ? showText : hideText;
   }

}
