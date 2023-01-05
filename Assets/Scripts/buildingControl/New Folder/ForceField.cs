using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public GameObject forceField;
    public AudioSource fieldPlayer;
    public AudioClip forceVoice;
    // fade speed length
    private float fadeSpeed = 0.5f;
    //Pause length between fades
    private float fadePause = 3f;
    private Material material;
    private bool flag = true;
    private float v;
    
    void Start() 
    {
        fieldPlayer = GetComponent<AudioSource>();
        //if(forceField == null){
            forceField = GameObject.Find("HexgonSphere");
        //}

        //foreach(GameObject forcefield in forceField){
            material = forceField.GetComponent<Renderer>().material;
            material.SetColor("_MainColor", new Color(0f,0f,0f,0f));
        //}
        v = fieldPlayer.volume;
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
        fieldPlayer.volume = v;
        fieldPlayer.PlayOneShot(forceVoice);
        yield return Fade(material, 1f);
        // wait
        yield return new WaitForSeconds(fadePause);
        // fade out
        StartCoroutine(AudioFadeout());
        yield return Fade(material, 0f);
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
            forceField.SetActive(false);
        }
    }

    IEnumerator AudioFadeout() 
    {
        float head = 2f;
        while (head >= 0f)
        {
            head -= Time.deltaTime;
            fieldPlayer.volume = v * head;
            yield return null;
        }
        fieldPlayer.Stop();
    }
}
