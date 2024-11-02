using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image uiImage; // Assign your UI Image here
    public float fadeDuration = 2.0f; // Duration of the fade-in in seconds
    private float elapsed = 0.0f;
    private bool isFadingIn = false;

    void Update()
    {
        if (isFadingIn && uiImage != null)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsed / fadeDuration); // Gradually changes alpha from 0 to 1
            Color newColor = uiImage.color;
            newColor.a = alpha;
            uiImage.color = newColor;

            // Stop fading in when duration is complete
            if (elapsed >= fadeDuration)
            {
                isFadingIn = false;
            }
        }
    }

    public void StartFadeIn()
    {
        // Reset variables and begin fading in
        elapsed = 0.0f;
        isFadingIn = true;

        // Optionally, set initial alpha to 0 for immediate fade-in
        Color newColor = uiImage.color;
        newColor.a = 0.0f;
        uiImage.color = newColor;
    }
}
