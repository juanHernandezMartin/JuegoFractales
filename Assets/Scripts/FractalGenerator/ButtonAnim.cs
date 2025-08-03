using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float sizeIncrease;
    public float timeToScale;
    private Vector3 originalSize;

    public void Awake()
    {
        originalSize = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(originalSize * sizeIncrease, timeToScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalSize, timeToScale);
    }
}

