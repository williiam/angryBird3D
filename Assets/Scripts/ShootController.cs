using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ShootController : MonoBehaviour
{
    [SerializeField]
    private GameObject Bird;

    [SerializeField]
    private Transform LeftPoint;

    [SerializeField]
    private Transform RightPoint;

    [SerializeField]
    private LineRenderer ShootLine;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Vector3 startPosition;

    private Rigidbody rb;

    private GameObject bird;

    private bool isShoot = false;
    private float forceMultiplier = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ShootLine.positionCount = 3;
        startPosition = transform.position;
        generateBird();
    }

    // Update is called once per frame
    void Update()
    {
        ShootLine.SetPosition(0, LeftPoint.position);
        ShootLine.SetPosition(1, transform.position);
        ShootLine.SetPosition(2, RightPoint.position);
    }

    void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos-mousePressDownPos);
    }

    void OnMouseDrag() {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;

        if(!isShoot) TrajectoryDrawer.Instance.UpdateTrajectory(forceV, rb, transform.position);
    }

    void Shoot(Vector3 Force)
    {
        if(isShoot)    
            return;
        
        Vector3 force = new Vector3(Force.x, Force.y, Force.y);
        rb.AddForce(force * forceMultiplier );
        isShoot = true;
        TrajectoryDrawer.Instance.ClearTrajectory();
    }

    public void generateBird() {
        bird = Instantiate(Bird, transform.position, Quaternion.identity);
    }
}
