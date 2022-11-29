using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPointController : MonoBehaviour
{
    public Camera camera;
    public GameObject bird;
    private GameObject readyBird;
    private float speed = 100f;
    private bool canShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;    
    }

    // Update is called once per frame
    void Update()
    {
        // invalid because the mouse see is 2D
        if(Input.GetMouseButton(0) && canShoot) {
            Vector3 direction = Input.mousePosition - this.transform.position;
            bird.GetComponent<Rigidbody>().velocity = direction * speed;
            canShoot = false;
            Debug.Log(bird.GetComponent<Rigidbody>().velocity);
        }
    }

    public void setNewBird() {
        readyBird = Instantiate(bird, this.transform.position, camera.transform.rotation);
    }
}
