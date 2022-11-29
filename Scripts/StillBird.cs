using System.Collections;
using UnityEngine;

public class StillBird : MonoBehaviour
{
    public float WaitForSeconds;

    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(WaitForSeconds);

        GetComponent<Animator>().enabled = true;
    }
}