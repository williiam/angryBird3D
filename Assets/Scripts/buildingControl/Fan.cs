using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float fanSpeed;
    public float force;

    void Start()
    {
        fanSpeed = 10f;
        force = 10f;
    }

    void Update()
    {
        //transform.Rotate(Vector3.up * fanSpeed * Time.deltaTime);
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            collision.GetComponent<Rigidbody>().AddForce(Vector3.down * force * fanSpeed);
        }
    }
}
