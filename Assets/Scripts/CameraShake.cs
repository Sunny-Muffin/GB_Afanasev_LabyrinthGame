using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class CameraShake : MonoBehaviour
    {
        private void OnEnable()
        {
            Mine.OnTouched += ShakeCamera;
        }

        private void OnDisable()
        {
            Mine.OnTouched -= ShakeCamera;
        }

        private void ShakeCamera(float shakeTime, float shakeMagnitude)
        {
            //Debug.Log("SHAAAKINNGGG!");
            StartCoroutine(Shake(shakeTime, shakeMagnitude));
        }

        private IEnumerator Shake (float time, float magnitude)
        {
            Vector3 originaPosition = transform.localPosition;
            float timeCount = 0.0f;

            while (timeCount < time)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float z = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, originaPosition.y, z);

                timeCount += Time.deltaTime;

                yield return null; // странная штука, подглядел у Brackeys, должна синхронизировать с апдейтом
            }
            transform.localPosition = originaPosition;
        }
    }
}
