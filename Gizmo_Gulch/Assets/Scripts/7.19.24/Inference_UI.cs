using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inference_UI : MonoBehaviour
{
    public static Inference_UI instance;

    public Slider loadingBar;
    public TextMeshProUGUI inferenceText;
    public AudioSource loadingSound;
    public AudioSource completionSound;

    private float loadingDuration;
    private bool isLoading = false;

    void Start()
    {
        instance = this;
        inferenceText.gameObject.SetActive(false);
        loadingBar.gameObject.SetActive(false);
    }

    public void StartLoading(int identifier)
    {
        if (loadingSound != null && !isLoading)
        {
            loadingDuration = loadingSound.clip.length;
            loadingBar.maxValue = loadingDuration;
            loadingBar.value = 0;
            inferenceText.gameObject.SetActive(true);
            loadingBar.gameObject.SetActive(true);
            loadingSound.Play();
            StartCoroutine(UpdateLoadingBar(identifier));
        }
    }

    private IEnumerator UpdateLoadingBar(int identifier)
    {
        float elapsedTime = 0f;
        int dotCount = 0;
        isLoading = true;

        while (elapsedTime < loadingDuration)
        {
            elapsedTime += Time.deltaTime;
            loadingBar.value = elapsedTime;

            // Update inference text with dots
            dotCount = (int)((elapsedTime / loadingDuration) * 9) % 4; // Cycle through 0, 1, 2, 3
            inferenceText.text = "GENERATING THING" + new string('.', dotCount);

            yield return null;
        }

        // Ensure the bar is full and play completion sound
        loadingBar.value = loadingDuration;
        completionSound.Play();

        // Deactivate the loading bar and inference text
        inferenceText.gameObject.SetActive(false);
        loadingBar.gameObject.SetActive(false);
        isLoading = false;

        Node_Manager_V2.instance.AddNode(identifier);
    }



}