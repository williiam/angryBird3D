using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pigController : MonoBehaviour
{
    public Image pig;
    private float pigRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        pig.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startcoroutine() {
        StartCoroutine(ShowPig());
    }

    IEnumerator ShowPig() {
        // pig scale is 1.3, 0.8, 0
        float timer = 0f;
        while(timer < 1f) {
            pig.transform.localScale = new Vector3(timer * 1.3f, timer * 0.8f , 0f);
            timer += Time.fixedUnscaledDeltaTime * pigRate;
            yield return null;
        }
    }
}
