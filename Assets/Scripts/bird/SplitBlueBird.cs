using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBlueBird : MonoBehaviour
{

    public GameObject Feathers;
    public GameObject FeatherExplosion;

    public float ReleaseTime = 0.5f;
    public float DestructionTime = 5f;

    public Rigidbody Rb;

    public void Start()
    {
       StartCoroutine(ReleaseCoroutine());
    }

    IEnumerator ReleaseCoroutine()
    {
        yield return new WaitForSeconds(ReleaseTime);
        StartCoroutine(ExplodCoroutine());
    }

    IEnumerator ExplodCoroutine()
    {
        yield return new WaitForSeconds(DestructionTime);
        if(gameObject!=null)
        {
            Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
