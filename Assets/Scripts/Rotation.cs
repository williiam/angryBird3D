using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float speed = 2.5f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.down*speed);
    }
}
