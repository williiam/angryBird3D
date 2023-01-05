using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    private GameObject CameraInitialPosition;

    [SerializeField]
    private LineRenderer ShootLine;

    [SerializeField]
    private CinemachineVirtualCamera vCm;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Vector3 startPosition;

    private Rigidbody rb;

    private BaseBird bird;

    private AudioSource shootPlayer;

    public AudioClip Slingshot;
    
    public AudioClip SlingshotRelease;
    
    public AudioClip Flying;

    // stage 0: 還沒發射, stage 1: dragging, stage2: 射出去了🥵
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
        shootPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int stage = GameManagerV2.Instance.getCameraStatus();
        bird = BirdManager.Instance.GetCurrentBird();

        if(bird == null) {
            vCm.Follow = transform;
            vCm.LookAt = transform;
            ShootLine.positionCount = 2;
            ShootLine.SetPosition(0, LeftPoint.transform.position);
            ShootLine.SetPosition(1, RightPoint.transform.position);
            return;
        }

        if(stage == 0 || stage == 1) {
            ShootLine.positionCount = 3;
            ShootLine.SetPosition(0, LeftPoint.transform.position);
            ShootLine.SetPosition(1, bird.GetComponent<Transform>().position);
            ShootLine.SetPosition(2, RightPoint.transform.position);
            bird.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if(stage == 0) {
            bird.GetComponent<Transform>().position = startPosition;
            vCm.Follow = transform;
            vCm.LookAt = transform;
        }

        if(stage == 1) {
            vCm.Follow = bird.GetComponent<Transform>();
            vCm.LookAt = transform;            
        }

        if(stage == 2) {
            vCm.Follow = bird.GetComponent<Transform>();
            vCm.LookAt = bird.GetComponent<Transform>();
        }

    }

    void OnMouseDown()
    {
        if(bird==null){
            return;
        }
        shootPlayer.PlayOneShot(Slingshot);
        BirdManager.Instance.SetReady(true);
        bird = BirdManager.Instance.GetCurrentBird();
        mousePressDownPos = Input.mousePosition;
        SetStage(1);
    }

    void OnMouseUp()
    {
        if(bird==null){
            return;
        }
        shootPlayer.PlayOneShot(SlingshotRelease);
         SetStage(2);
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
        BirdManager.Instance.OnBirdShoot();
    }

    void OnMouseDrag() {
        if(bird==null){
            return;
        }
        int stage = GameManagerV2.Instance.getCameraStatus();
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;
        Vector3 newPos = startPosition + (( new Vector3(forceInit.x, forceInit.y, 1.5f * forceInit.y) / rb.mass ) * Time.fixedDeltaTime);
        if(newPos.y < 1) newPos.y = 1;
        if(stage == 1) bird.GetComponent<Transform>().position = newPos;

        Rigidbody _rb = bird.GetComponent<Rigidbody>();
        TrajectoryDrawer.Instance.UpdateTrajectory(forceV, _rb, newPos);
    }

    void Shoot(Vector3 Force)
    {
        shootPlayer.PlayOneShot(Flying);
        Rigidbody _rb = bird.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(Force.x, Force.y, 1.5f * Force.y) * forceMultiplier;
        _rb.AddForce(force);
        TrajectoryDrawer.Instance.ClearTrajectory();
        bird.Release();
    }

    // public methods
    public int GetStage()
    {
        return GameManagerV2.Instance.getCameraStatus();;
    }

    public int SetStage(int newStage)
    {
        GameManagerV2.Instance.setCameraStatus(newStage);
        return newStage;
    }
}
