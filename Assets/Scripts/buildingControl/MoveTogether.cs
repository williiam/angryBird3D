using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTogether : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    public float _speed;
    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    private GameObject boss;

    private bool flag = true;

    void Start()
    {
        boss = GameObject.Find("PigBoss");
        //Debug.Log(boss);
        if(boss == null){

            TargetNextWaypoint();
        }
    }

    void FixedUpdate()
    {
        boss = GameObject.Find("PigBoss");

        if(boss == null){
            if (flag){
                StartCoroutine(move());
            }
        }
    }

    IEnumerator move(){
        flag = false;
        TargetNextWaypoint();
        
        float elapsedPercentage = 0f;

        while(elapsedPercentage < 1f) {
            _elapsedTime += Time.deltaTime;
            elapsedPercentage = _elapsedTime / _timeToWaypoint;
            elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
            this.transform.position = Vector3.Lerp(_targetWaypoint.position, _previousWaypoint.position, elapsedPercentage);
            yield return null;
        }
        TargetNextWaypoint();
        flag = true;
        yield return new WaitForSeconds(3f);
    }

    void TargetNextWaypoint(){
        //Debug.Log("_previousWaypoint: " + _previousWaypoint);
        //Debug.Log("_targetWaypointIndex: " + _targetWaypointIndex);
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
