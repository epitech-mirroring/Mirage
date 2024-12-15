using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DieMenu : MonoBehaviour
{
    private Image img;
    public float alpha = 0f;
    public float speed = 1f;

    private void OnEnable()
    {
        img = GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * speed;
            alpha = Mathf.Clamp01(alpha);
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            yield return null;
        }
    }
}
