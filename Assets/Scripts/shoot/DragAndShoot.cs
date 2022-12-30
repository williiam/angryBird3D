using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    public GameObject hook;
    private AudioSource DASplayer;
    public AudioClip Slingshot;
    public AudioClip SlingshotRelease;
    public AudioClip Flying;
    public AudioClip BirdCollision;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Vector3 startPosition;

    private Rigidbody rb;
    private Joint joint;

    private bool isShoot = false;
    private float forceMultiplier = 3;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DASplayer = GetComponent<AudioSource>();
        startPosition = transform.position;
    }

    void Update() {
        if(!isShoot) {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.zero);
            transform.position = startPosition;
        }
    }

    void OnMouseDown()
    {
        DASplayer.PlayOneShot(Slingshot);
        mousePressDownPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        DASplayer.PlayOneShot(SlingshotRelease);
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
    }

    void OnMouseDrag() 
    {
        Vector3 forceInit = (mousePressDownPos - Input.mousePosition);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;

        if(!isShoot) TrajectoryDrawer.Instance.UpdateTrajectory(forceV, rb, transform.position);
    }

    void Shoot(Vector3 Force)
    {
        DASplayer.PlayOneShot(Flying);
        if(isShoot)    
            return;
        
        Vector3 force = new Vector3(Force.x, Force.y, Force.y);
        rb.AddForce(force * forceMultiplier );
        isShoot = true;
        TrajectoryDrawer.Instance.ClearTrajectory();
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(.5f);

        Destroy(GetComponent<SpringJoint>());
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(5f);

        //GameManagerV2.Instance.SetNewBird();
        // hook.GetComponent<ShootController>().generateBird();
        // GameManagerV2.Instance.BirdDestroy.Play();
        // Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}