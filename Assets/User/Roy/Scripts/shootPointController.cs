using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPointController : MonoBehaviour
{
    private const bool DEBUGMODE = false;
    public Camera camera;
    public GameObject bird;
    private GameObject readyBird;
    private float force = 15f;
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
            // 將座標轉換成世界座標
            //Vector3 pos = camera.ScreenToWorldPoint(bird.transform.position);
            Vector3 pos = bird.transform.position;
            Vector3 mousePos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, bird.transform.position.z));
            mousePos.y -= 1.87f;

            if(DEBUGMODE) {
                Debug.Log("mouse position: " + mousePos);
                Debug.Log("bird position: " + pos);
            }
            // 設定direction
            Vector3 direction = new Vector3(mousePos.x - pos.x, mousePos.y - pos.y, 0f);
            direction = direction.normalized * force;
            direction += Vector3.forward * force;

            if(DEBUGMODE)
                Debug.Log("direction: " + direction);
            
            // 給readybird速度
            readyBird.GetComponent<Rigidbody>().velocity = direction;
            if(DEBUGMODE)
                Debug.Log("velocity: " + readyBird.GetComponent<Rigidbody>().velocity);
            canShoot = false;
        }
    }

    public void setNewBird() {
        readyBird = Instantiate(bird, this.transform.position, camera.transform.rotation);
    }
}
