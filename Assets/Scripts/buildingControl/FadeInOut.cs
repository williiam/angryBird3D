using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public GameObject forceField;
    void start()
    {
        StartCoroutine(fadeInOut());
        // Destroy(gameObject, 1f);
    }

    IEnumerator fadeInOut(){
        forceField = GameObject.Find("StoneBlock");
        Debug.Log(forceField);

        Renderer objRenderer = forceField.transform.GetComponent<Renderer>();
        Debug.Log(objRenderer);
        
        Material objMaterial = objRenderer.material;
        Debug.Log(objMaterial);

        objMaterial.SetOverrideTag("RenderType","Transparent");
        objMaterial.SetInt("_SrcBlend",(int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        objMaterial.SetInt("_DstBlend",(int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        objMaterial.SetInt("_ZWrite",0);        
        objMaterial.DisableKeyword("ALPHATEST_ON");
        objMaterial.EnableKeyword("ALPHABLEND_ON");
        objMaterial.DisableKeyword("ALPHAPREMULTIPLY_ON");
        objMaterial.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        Color cInitialColor = objRenderer.material.color;
        Color cTargetColor = new Color(cInitialColor.r,cInitialColor.g,cInitialColor.b,0f);

        float fElapsedTime = 0f;
        float fFadeDuration = 1f;

        while(fElapsedTime < fFadeDuration){
            fElapsedTime += Time.deltaTime;
            objRenderer.material.color = Color.Lerp(cInitialColor,cTargetColor,fElapsedTime/fFadeDuration);
            yield return null;
        }
    }

}
