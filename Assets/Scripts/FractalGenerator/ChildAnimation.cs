using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ChildAnimation : MonoBehaviour
{
    public List<Transform> childParts;
    public float animationDuration = 1f;
    public float animationScale = 2f;

    private bool isAnimating = false;

    public void AnimateChild()
    {
        if (isAnimating) return; // Prevent multiple animations at the same time
        isAnimating = true;
        StartCoroutine(ResetAnimationState());
        foreach (Transform childPart in childParts)
        {
            Vector3 originalScale = childPart.localScale;
            childPart.DOScale(childPart.localScale * animationScale, animationDuration)
                .SetEase(Ease.OutExpo)
                .OnComplete(() =>
                {
                    childPart.DOScale(originalScale, animationDuration)
                        .SetEase(Ease.InExpo);
                });
        }

    }

    //coroutine to set isAnimating to false after the animation duration
    private IEnumerator ResetAnimationState()
    {
        yield return new WaitForSeconds(animationDuration*2.1f);
        isAnimating = false;
    }
}
