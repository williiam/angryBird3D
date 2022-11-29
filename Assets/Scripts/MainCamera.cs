using System;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Slingshot;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        GameObject pos = Bird == null ? Slingshot : Bird;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, Math.Max(pos.transform.position.z - 10, _startPosition.z)), Time.deltaTime * 2.5f);
    }
}
