using System.Collections;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    private TMP_Text textMeshPro;
    public float totalTypingTime = 5f; // Total tid f�r typning i sekunder

    private string fullText;

    private void Start()
    {
        // H�mta referensen till TextMeshPro-komponenten p� detta objekt
        textMeshPro = GetComponent<TMP_Text>();

        // Spara den ursprungliga texten f�r senare anv�ndning
        fullText = textMeshPro.text;

        // Rensa texten f�r att f�rbereda f�r typning
        textMeshPro.text = string.Empty;

        // Ber�kna typningshastigheten baserat p� den totala tiden och antalet bokst�ver
        float typingSpeed = CalculateTypingSpeed(totalTypingTime, fullText.Length);

        // Starta typningseffekten
        StartCoroutine(TypeText(typingSpeed));
    }

    // Metod f�r att ber�kna typningshastigheten baserat p� den totala tiden och antalet bokst�ver
    private float CalculateTypingSpeed(float totalTypingTime, int totalLetters)
    {
        // Ber�kna typningshastigheten baserat p� formeln
        return totalTypingTime / totalLetters;
    }

    // Coroutine f�r att simulera typningseffekten
    IEnumerator TypeText(float typingSpeed)
    {
        // Iterera genom varje bokstav i texten
        foreach (char letter in fullText)
        {
            // L�gg till varje bokstav till texten
            textMeshPro.text += letter;

            // V�nta den specificerade tiden innan n�sta bokstav
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
