using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public GameObject Smoke;

    void OnCollisionEnter(Collision other)
    {
        if (other.relativeVelocity.magnitude > 5f)
        {
            Destroy();
            if(other.gameObject.tag == "Bird") {
                GameManagerV2.Instance.AddScore(10000);
                Debug.Log("add 10000");
            } else {
                GameManagerV2.Instance.AddScore(10000);
                Debug.Log("add 8000");
            }
        }
    }

    private void Destroy()
    {
        // GameManager.Instance.PigHit.Play();
        // GameManager.Instance.PigDestroy.Play();
        GameObject smoke = Instantiate(Smoke, transform.position, Quaternion.identity);
        // GameManager.Instance.AddScore(5000, transform.position, Color.green);
        Destroy(smoke, 3);
        Destroy(gameObject);
    }

}