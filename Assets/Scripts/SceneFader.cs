using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1.0f;
        float a = curve.Evaluate(t);

        while(t > 0.0f)
        {
            t -= Time.deltaTime;
            a = curve.Evaluate(t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            yield return null;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0.0f;
        float a = curve.Evaluate(t);

        while (t < 1.0f)
        {
            t += Time.deltaTime;
            a = curve.Evaluate(t);
            img.color = new Color(img.color.r, img.color.g, img.color.b, a);
            yield return null;
        }

        SceneManager.LoadScene(scene);
    }
}
