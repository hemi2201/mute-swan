using System.Collections;
using TMPro;
using UnityEngine;

public class UiFade : MonoBehaviour
{
    public TMP_Text[] textMeshProTexts; 
    public float fadeDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // F�r att f�rs�kra oss om att texten �r synlig fr�n b�rjan
        SetAlphaForAll(1f);
    }

    // Metod f�r att starta fade-effekten p� alla TextMeshPro-objekt
    public void StartFadeForAll()
    {
        // Starta en korutin f�r fade f�r varje TextMeshPro-objekt
        foreach (TMP_Text textMeshProText in textMeshProTexts)
        {
            StartCoroutine(FadeText(textMeshProText.color.a, 0f, fadeDuration, textMeshProText));
        }
    }

    // Metod f�r att stoppa fade-effekten p� alla TextMeshPro-objekt
    public void StopFadeForAll()
    {
        // Starta en korutin f�r fade f�r varje TextMeshPro-objekt
        foreach (TMP_Text textMeshProText in textMeshProTexts)
        {
            StartCoroutine(FadeText(textMeshProText.color.a, 1f, fadeDuration, textMeshProText));
        }
    }

    // Korutin f�r fade-effekten p� en enskild TextMeshPro-objekt
    IEnumerator FadeText(float startAlpha, float targetAlpha, float duration, TMP_Text textMeshProText)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Anv�nd Lerp f�r att f� ett smidigt �verg�ngsv�rde mellan startAlpha och targetAlpha
            SetAlpha(textMeshProText, Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration));

            elapsedTime += Time.deltaTime;

            yield return null; // V�nta p� n�sta frame
        }

        // Se till att slutv�rdet �r exakt n�r �verg�ngen �r klar
        SetAlpha(textMeshProText, targetAlpha);
    }

    // Hj�lpmetod f�r att st�lla in alpha-v�rdet p� en enskild TMP-text
    void SetAlpha(TMP_Text textMeshProText, float alpha)
    {
        Color color = textMeshProText.color;
        color.a = alpha;
        textMeshProText.color = color;
    }

    // Hj�lpmetod f�r att st�lla in alpha-v�rdet p� alla TMP-texter
    void SetAlphaForAll(float alpha)
    {
        foreach (TMP_Text textMeshProText in textMeshProTexts)
        {
            SetAlpha(textMeshProText, alpha);
        }
    }
}
