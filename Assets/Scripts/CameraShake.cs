using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float dur;
    public void CallShake(float duration)
    {
        dur = duration;
        StartCoroutine("Shake");

    }

    public IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;

        float elapsed = 0.0f;

        while (elapsed < dur)
        {
            float x = Random.Range(-1, 1) * 0.5f;
            float y = Random.Range(-1, 1) * 0.5f;

            transform.position = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.position = originalPosition;
    }
}
