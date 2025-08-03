using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AddChildButton : MonoBehaviour
{
    public float animTime = 0.5f;
    public Fractal fractal;
    public List<GameObject> childButtons;
    public List<GameObject> childModels;
    public GameObject removeLastChildButton;
    public FractalGenerator fractalGenerator;

    private List<ChildButton> childButtonsScrits;
    private float offsetBtweenChildButtons;

    private void Awake()
    {
        childButtonsScrits = new List<ChildButton>();
        foreach (GameObject childButton in childButtons)
        {
            childButtonsScrits.Add(childButton.GetComponent<ChildButton>());
        }
        offsetBtweenChildButtons = childButtons[1].transform.position.x - childButtons[0].transform.position.x;
    }


    public void AddChild()
    {
        offsetBtweenChildButtons = childButtons[1].transform.position.x - childButtons[0].transform.position.x;
        fractalGenerator.ResetFractal();
        //transform.position += new Vector3(offsetBtweenChildButtons, 0, 0);
        transform.DOMoveX(transform.position.x + offsetBtweenChildButtons, animTime).SetEase(Ease.OutBack);
        int childIndex = fractal.GetFirstInactiveChildIndex();
        fractal.isChildActive[childIndex] = true;
        fractal.ActiveChildren.Add(fractal.children[childIndex]);
        print(fractal.ActiveChildren.Count);
        ChildButton childButton = childButtonsScrits[fractal.ActiveChildren.Count - 1];
        childButton.gameObject.SetActive(true);
        childModels[childIndex].SetActive(true);
        
        removeLastChildButton.SetActive(true);
        //removeLastChildButton.transform.position = transform.position + new Vector3(offsetBtweenChildButtons, 0, 0);
        float targetX = transform.position.x + offsetBtweenChildButtons*2;
        Tween tweenOfRemoveButton = removeLastChildButton.transform.DOMoveX(targetX, animTime).SetEase(Ease.OutBack);

        if (fractal.ActiveChildren.Count == 4)
        {
            tweenOfRemoveButton.Kill();
            gameObject.SetActive(false);
        }
    }

    public void RemoveLastChild()
    {
        offsetBtweenChildButtons = childButtons[1].transform.position.x - childButtons[0].transform.position.x;
        fractalGenerator.ResetFractal();
        if (fractal.ActiveChildren.Count == 0) return;
        int lastChildIndex = fractal.ActiveChildren.Count - 1;
        fractal.isChildActive[lastChildIndex] = false;
        fractal.ActiveChildren.RemoveAt(lastChildIndex);
        childButtonsScrits[lastChildIndex].gameObject.SetActive(false);
        childModels[lastChildIndex].SetActive(false);
        //transform.position += new Vector3(-offsetBtweenChildButtons, 0, 0);
        float targetX = transform.position.x - offsetBtweenChildButtons;
        transform.DOMoveX(targetX, animTime).SetEase(Ease.InBack);
        //removeLastChildButton.transform.position = transform.position + new Vector3(offsetBtweenChildButtons, 0, 0);
        targetX = transform.position.x;
        removeLastChildButton.transform.DOMoveX(targetX, animTime).SetEase(Ease.InBack);
        gameObject.SetActive(true);

        if (fractal.ActiveChildren.Count == 0)
        {
            removeLastChildButton.SetActive(false);
        }
    }
}
