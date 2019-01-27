using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowControl : MonoBehaviour
{
    public SpriteRenderer[] slides;
    public float durationTime = 3.0f;
    public float transitionTime = 0.5f;

    private float intervalTime;
    private int currentIndex;

    void Awake()
    {
        intervalTime = 0f;
        currentIndex = 0;
        foreach (SpriteRenderer renderer in slides) {
            renderer.color = Color.clear;
        }
        slides[currentIndex].color = Color.white;
    }

    void Update()
    {
        if (intervalTime > durationTime) {
            StartCoroutine(HideSlide(slides[currentIndex], transitionTime));
            currentIndex = (currentIndex == slides.Length - 1) ? 0 : currentIndex + 1;
            StartCoroutine(ShowSlide(slides[currentIndex], transitionTime));
            intervalTime = 0f;
        }
        intervalTime += Time.deltaTime;
    }

    private IEnumerator ShowSlide(SpriteRenderer slide, float time) {
        float elapsedTime = 0;
        while (elapsedTime < time) {
            slide.color = Color.Lerp(Color.clear, Color.white, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator HideSlide(SpriteRenderer slide, float time) {
        float elapsedTime = 0;
        while (elapsedTime < time) {
            slide.color = Color.Lerp(Color.white, Color.clear, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
