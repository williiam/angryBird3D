using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float fanSpeed;
    public float force;

    void Start()
    {
        fanSpeed = 50f;
        force = 10f;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * fanSpeed * Time.deltaTime);
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Pig"))
        {
            collision.GetComponent<Rigidbody>().AddForce(Vector3.up * force * fanSpeed);
        }
    }
}
