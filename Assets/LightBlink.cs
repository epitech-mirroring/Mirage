using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
     private Light lightComp;
    public float intensityStep = 0.1f;
    public float waitingTime = 1f;
    public float maxIntensity = 150f;
    public float minIntensity = 50f;

    private void Start()
    {
        lightComp = GetComponent<Light>();
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            while (lightComp.intensity < maxIntensity)
            {
                lightComp.intensity = Mathf.Clamp(lightComp.intensity + intensityStep * Time.deltaTime, minIntensity, maxIntensity);
                yield return null;
            }
            yield return new WaitForSeconds(waitingTime);
            while (lightComp.intensity > minIntensity)
            {
                lightComp.intensity = Mathf.Clamp(lightComp.intensity - intensityStep * Time.deltaTime, minIntensity, maxIntensity);
                yield return null;
            }
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
