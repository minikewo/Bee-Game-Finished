using TMPro;
using UnityEngine;

public class BeePopUp : MonoBehaviour
{
    public CanvasGroup canvasGroup;   // drag your CanvasGroup here
    public TextMeshProUGUI messageText;      // drag your TextMeshPro text here
    public float fadeDuration = 1f;   // how long to fade in/out
    public float displayTime = 7f;   // how long popup stays before fading out

    private bool isShowing = false;

    public void ShowAchievement(string message)
    {
        if (!isShowing) // prevent overlapping
            StartCoroutine(ShowPopupRoutine(message));
    }

    private System.Collections.IEnumerator ShowPopupRoutine(string message)
    {
        isShowing = true;
        messageText.text = message;

        // Fade in
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1;

        // Wait
        yield return new WaitForSeconds(displayTime);

        // Fade out
        t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 0;

        isShowing = false;
    }
}



