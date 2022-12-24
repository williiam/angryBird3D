using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ShootController : MonoBehaviour
{
    public static ShootController Instance;

    [SerializeField]
    private GameObject Bird;

    [SerializeField]
    private GameObject LeftPoint;

    [SerializeField]
    private GameObject RightPoint;

    [SerializeField]
    private LineRenderer ShootLine;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Vector3 startPosition;

    private Rigidbody rb;

    private BaseBird bird;

    // stage 0: 還沒發射, stage 1: dragging, stage2: 射出去了🥵
    private int stage = 0;
    private float forceMultiplier = 9;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        // generateBird();
        ShootLine.positionCount = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        bird = BirdManager.Instance.GetCurrentBird();
        if(bird==null){
            return;
        }
        if(stage == 0 || stage == 1) {
            ShootLine.SetPosition(0, LeftPoint.transform.position);
            ShootLine.SetPosition(1, bird.transform.position);
            ShootLine.SetPosition(2, RightPoint.transform.position);
            bird.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        
        if(stage == 0) {
            bird.transform.position = startPosition;
        }
    }

    void OnMouseDown()
    {
        bird = BirdManager.Instance.GetCurrentBird();
        if(bird==null){
            return;
        }
        mousePressDownPos = Input.mousePosition;
        stage = 1;
    }

    void OnMouseUp()
    {
        stage = 2;
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }

    void OnMouseDrag() {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;
        Vector3 newPos = ( new Vector3(forceInit.x, forceInit.y, forceInit.y) / rb.mass ) * Time.fixedDeltaTime;
    
        if(stage == 1) bird.transform.position = startPosition + newPos;

        Rigidbody _rb = bird.GetComponent<Rigidbody>();
        TrajectoryDrawer.Instance.UpdateTrajectory(forceV, _rb, startPosition + newPos);
    }

    void Shoot(Vector3 Force)
    {
        Rigidbody _rb = bird.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(Force.x, Force.y, Force.y) * forceMultiplier;
        _rb.AddForce(force);
        TrajectoryDrawer.Instance.ClearTrajectory();
        bird.Release();
    }

    // public methods
    public int GetStage()
    {
        return stage;
    }

    public int SetStage(int newStage)
    {
        stage = newStage;
        return stage;
    }
}
