using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTogether : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _speed;
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
        while(_elapsedTime < 1f) {
            //Debug.Log("ppppp" + elapsedPercentage);
            _elapsedTime += Time.deltaTime * 0.003f;

            elapsedPercentage = _elapsedTime / _timeToWaypoint;

            elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
            
            transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
            //float distance = new Vector3(_targetWaypoint.position.x - _previousWaypoint.position.x, _targetWaypoint.position.y - _previousWaypoint.position.y, _targetWaypoint.position.z - _previousWaypoint.position.z).distance;
            /*
            this.transform.position = new Vector3(
                _previousWaypoint.position.x + (_targetWaypoint.position.x - _previousWaypoint.position.x) * _elapsedTime,
                _previousWaypoint.position.y + (_targetWaypoint.position.y - _previousWaypoint.position.y) * _elapsedTime,
                _previousWaypoint.position.z + (_targetWaypoint.position.z - _previousWaypoint.position.z) * _elapsedTime
            );
            */
        }        
        if (elapsedPercentage >= 1) {
            
            TargetNextWaypoint();
        }
        yield return new WaitForSeconds(3f);
        flag = true;
        yield break;
    }

    void TargetNextWaypoint(){
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
