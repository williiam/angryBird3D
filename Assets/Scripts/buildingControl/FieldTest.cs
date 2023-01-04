using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldTest: MonoBehaviour
{
	// public float fadeInTime = 0.5f;
    // public float fadeOutTime = 0.5f;
    private GameObject forcefield;

    void Start()
    {
        forcefield = GameObject.Find("ForceField");
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(FadeIn());
            yield return StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        // rend.enabled = true;
        // float t = 0.0f;
        // while (t < fadeInTime)
        // {
        //     t += Time.deltaTime;
        //     float a = Mathf.Lerp(0.0f, 1.0f, t / fadeInTime);
        //     rend.material.color = new Color(1, 1, 1, a);
        //     yield return null;
        // }
        forcefield.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0.5f,3.0f));
    }

    IEnumerator FadeOut()
    {
        // float t = 0.0f;
        // while (t < fadeOutTime)
        // {
        //     t += Time.deltaTime;
        //     float a = Mathf.Lerp(1.0f, 0.0f, t / fadeOutTime);
        //     rend.material.color = new Color(1, 1, 1, a);
        //     yield return null;
        // }
        // rend.enabled = false;

        forcefield.SetActive(false);
        yield return new WaitForSeconds(Random.Range(0.5f,3.0f));
    }
}