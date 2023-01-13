using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimation : MonoBehaviour
{
    private const int FadeCompFrame = 60;

    public void EnableUI(CanvasGroup group)
    {
        group.alpha = 0f;
        StartCoroutine(FadeIn(group, 0f));
    }

    public void DisableUI(CanvasGroup group)
    {
        group.alpha = 1f;
        StartCoroutine(FadeOut(group, 1f));
    }

    public void ForceDisableUI(CanvasGroup group)
    {
        group.alpha = 0f;
    }

    private IEnumerator FadeIn(CanvasGroup group, float progress)
    {
        group.alpha = progress;

        yield return null;
        progress += 1f / FadeCompFrame;
        if (progress < 1f) StartCoroutine(FadeIn(group, progress));
    }

    private IEnumerator FadeOut(CanvasGroup group, float progress)
    {
        group.alpha = progress;

        yield return null;
        progress -= 1f / FadeCompFrame;
        if (progress > 0f) StartCoroutine(FadeOut(group, progress));
    }
}
