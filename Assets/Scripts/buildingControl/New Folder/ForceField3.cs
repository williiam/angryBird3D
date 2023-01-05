using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField3 : MonoBehaviour
{
    public GameObject forceField;
    // fade speed length
    private float fadeSpeed = 0.5f;
    //Pause length between fades
    private float fadePause = 2f;
    private Material material;
    private bool flag = true;
    void Start() 
    {
        //if(forceField == null){
            forceField = GameObject.Find("HexgonSphere3");
        //}

        //foreach(GameObject forcefield in forceField){
            material = forceField.GetComponent<Renderer>().material;
            material.SetColor("_MainColor", new Color(1f,1f,1f,1f));
        //}
    }

    void Update()
    {
        if(flag) {
            StartCoroutine(fadeInOut());
        }
    }

    IEnumerator fadeInOut()
    {
        flag = false;
        // fade in
        forceField.SetActive(true);
        yield return Fade(material, 1f);
        // wait
        yield return new WaitForSeconds(fadePause);
        // fade out
        yield return Fade(material, 0f);
        //forcefield.SetActive(false);
        // wait
        yield return new WaitForSeconds(fadePause);
        flag = true;
    }

    IEnumerator Fade(Material mat, float targetAlpha)
    {
        var newAlpha = (targetAlpha == 0f) ? 1f : 0f;
        if(targetAlpha == 1f) {
            while(newAlpha < targetAlpha)
            {
                newAlpha += fadeSpeed * Time.deltaTime;
                mat.SetColor("_MainColor", new Color(newAlpha, newAlpha, newAlpha, newAlpha));
                yield return null;
            }
        } 
        else 
        {
            while(newAlpha > targetAlpha)
            {
                newAlpha -= fadeSpeed * Time.deltaTime;
                mat.SetColor("_MainColor", new Color(newAlpha, newAlpha, newAlpha, newAlpha));
                yield return null;
            }
            // foreach(GameObject field in forceField){
                forceField.SetActive(false);
            // }
        }
    }
}
