using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public GameObject forceField;
    // fade speed length
    public float fadeSpeed = 0.1f;
    //Pause length between fades
    public float fadePause = 2.0f;

    void Start()
    {
        StartCoroutine(fadeInOut());
    }

    IEnumerator fadeInOut()
    {
        forceField = GameObject.Find("StoneBlock");
        Debug.Log(forceField);

        var material = forceField.GetComponent<Renderer>().material;
        Debug.Log(material);

        //forever
        while (true)
        {
            // fade out
            yield return Fade(material, 0);
            // wait
            yield return new WaitForSeconds(fadePause);
            // fade in
            yield return Fade(material, 1);  
            // wait
            yield return new WaitForSeconds(fadePause);
        }
    }

    IEnumerator Fade(Material mat, float targetAlpha)
    {
        while(mat.color.a != targetAlpha)
        {
            var newAlpha = Mathf.MoveTowards(mat.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newAlpha);
            yield return null;
        }
    }

}
