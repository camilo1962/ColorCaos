using System.Collections;
using UnityEngine;

public class ScoreEffect4 : MonoBehaviour
{
    [SerializeField] private float _destroyTime4;
    private Color currentColor4;

    public void Init4(Color col)
    {
        currentColor4 = col;

        StartCoroutine(Effect4());
    }

    private IEnumerator Effect4()
    {

        float timeElapsed4 = 0f;
        float speed = 1 / _destroyTime4;
        Vector3 startScale4 = Vector3.one * 0.64f;
        Vector3 endScale4 = Vector3.one * 1.32f;
        Vector3 scaleOffset4 = endScale4 - startScale4;
        Vector3 currentScale4 = startScale4;

        Color startColor4 = currentColor4;
        startColor4.a = 0.8f;
        Color endColor4 = currentColor4;
        endColor4.a = 0.2f;
        Color colorOffset4 = endColor4 - startColor4;
        Color c = startColor4;
        SpriteRenderer sr4 = GetComponent<SpriteRenderer>();
        sr4.color = c;

        while(timeElapsed4 < 1f)
        {
            timeElapsed4 += speed * Time.deltaTime;

            currentScale4 = startScale4 + timeElapsed4 * scaleOffset4;
            transform.localScale = currentScale4;

            c = startColor4 + timeElapsed4 * colorOffset4;
            sr4.color = c;

            yield return null;
        }

        Destroy(gameObject);
    }
}
