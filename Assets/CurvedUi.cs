using UnityEngine;

public class CurvedUIScript : MonoBehaviour
{
    public float curveAmount = 10f;

    void Update()
    {
        // Anv�nd �nskad logik f�r att justera canvasens form eller beteende.
        // Exempel: Roterar canvasen.
        transform.Rotate(0, curveAmount * Time.deltaTime, 0);
    }
}
