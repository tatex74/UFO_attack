using UnityEngine;
using System.Collections;

public class BreathingAnimation : MonoBehaviour
{
    public float baseScale = 1.0f;
    public float scaleVariation = 0.1f;
    public float breathingSpeed = 1.0f;
    public float hoverScaleVariation = 0.2f;
    public float hoverBreathingSpeed = 2.0f;
    public float transitionDuration = 0.5f; 

    private Vector3 initialScale;
    private float currentScaleVariation;
    private float currentBreathingSpeed;
    private bool isHovered = false;
    private float breathingTimer = 0f;

    void Start()
    {
        initialScale = transform.localScale;
        currentScaleVariation = scaleVariation;
        currentBreathingSpeed = breathingSpeed;
    }

    void Update()
    {
        breathingTimer += Time.deltaTime;
        float scale = 1.0f + Mathf.Sin(breathingTimer * currentBreathingSpeed) * currentScaleVariation;
        transform.localScale = initialScale * scale;
    }

    public void SetHovered(bool hovered){
        if (isHovered != hovered)
        {
            isHovered = hovered;
            StopAllCoroutines();  // Stop any ongoing transition
            StartCoroutine(SmoothTransition(hovered));
        }
    }

    private IEnumerator SmoothTransition(bool hovered)
    {
        float targetScaleVariation = hovered ? hoverScaleVariation : scaleVariation;
        float targetBreathingSpeed = hovered ? hoverBreathingSpeed : breathingSpeed;
        float initialScaleVariation = currentScaleVariation;
        float initialBreathingSpeed = currentBreathingSpeed;
        float elapsedTime = 0f;

        breathingTimer = 0f; // Reset the breathing timer

        while (elapsedTime < transitionDuration)
        {
            currentScaleVariation = Mathf.Lerp(initialScaleVariation, targetScaleVariation, elapsedTime / transitionDuration);
            currentBreathingSpeed = Mathf.Lerp(initialBreathingSpeed, targetBreathingSpeed, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure final values are set
        currentScaleVariation = targetScaleVariation;
        currentBreathingSpeed = targetBreathingSpeed;
    }
}