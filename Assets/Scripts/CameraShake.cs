using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.5f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {

    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            //float x = Random.Range(-1f, 1f) * shakeMagnitude;
            //float y = Random.Range(-1f, 1f) * shakeMagnitude;
            //transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = originalPosition;
    }
}
