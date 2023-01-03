using System.Collections;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    public float maxLightIntencity, minLightIntencity;
    public bool lightsEnabledOnStart;

    private Light myLight;
    private ParticleSystem myParticles;
    private bool lightOn, flickerLight;
    private float wantedLightIntencity;
    private Coroutine animateLights;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponentInChildren<Light>();
        myParticles = GetComponentInChildren<ParticleSystem>();     

        if (lightsEnabledOnStart)
            ToggleLight();
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerLight)//dim lights
        {
            if (wantedLightIntencity == 0 && myLight.intensity <= 0)
            {
                //disable light
                myLight.enabled = false;
                flickerLight = false;
            }
            else myLight.intensity = Mathf.MoveTowards(myLight.intensity, wantedLightIntencity, Time.deltaTime * 0.6f);
        }
    }

    private IEnumerator FlickerLight()
    {
        while (lightOn)
        {
            //Set random intencity
            wantedLightIntencity = Random.Range(minLightIntencity, maxLightIntencity);
            yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        }
    }

    //Turn light On/Off
    public void ToggleLight()
    {
        lightOn = !lightOn;
        if (lightOn)
        {
            myParticles.Play();
            myLight.enabled = true;
            animateLights = StartCoroutine(FlickerLight());
            flickerLight = true;
        }
        else
        {
            StopCoroutine(animateLights);
            wantedLightIntencity = 0;
            myParticles.Stop();
        }
    }
}
