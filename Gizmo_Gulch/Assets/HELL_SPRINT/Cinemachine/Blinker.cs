using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    public Image uiImage; // Assign your UI Image here
    public float fadeDuration = 2.0f; // Duration of the fade-out in seconds
    private float elapsed = 0.0f;
    private bool isFading = false;

    void Update()
    {
        if (isFading && uiImage != null)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsed / fadeDuration); // Gradually changes alpha from 1 to 0
            Color newColor = uiImage.color;
            newColor.a = alpha;
            uiImage.color = newColor;

            // Stop fading when duration is complete
            if (elapsed >= fadeDuration)
            {
                isFading = false;
            }
        }
    }

    public void StartFade()
    {
        // Reset variables and begin fading
        elapsed = 0.0f;
        isFading = true;
    }
}
