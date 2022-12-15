using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;

    [SerializeField]
    [Range(3, 30)]
    private int _lineSegmentCount = 20;

    [SerializeField]
    [Range(10, 100)]
    private int _showPercentage = 100;

    [SerializeField]
    private int _linePointCount;

    private List<Vector3> _linePoints = new List<Vector3>();

    public static TrajectoryDrawer Instance;

    private void Start() {
        _linePointCount = (int)(_lineSegmentCount * ( _showPercentage / 100f));
    }

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidBody, Vector3 startingPoint) {
        Vector3 velocity = ( forceVector / rigidBody.mass ) * Time.fixedDeltaTime;
        float FlightDuration = ( 2 * velocity.y) / Physics.gravity.y;
        float stepTime = FlightDuration / _lineSegmentCount;
        _linePoints.Clear();
        _linePoints.Add(startingPoint);
        for(int i = 1; i < _lineSegmentCount; i++) {
            float stepTimePassed = stepTime * i;
            Vector3 MovementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
            );
            Vector3 newPointOnLine =  -MovementVector + startingPoint;
            RaycastHit hit;
            if(Physics.Raycast(_linePoints[i - 1], newPointOnLine - _linePoints[i - 1], out hit, (newPointOnLine - _linePoints[i - 1]).magnitude)) {
                _linePoints.Add(hit.point);
                break;
            }
            _linePoints.Add(newPointOnLine);
        }
        
        lineRenderer.positionCount = _linePoints.Count;
        lineRenderer.SetPositions(_linePoints.ToArray());
    }

    public void ClearTrajectory() {
        lineRenderer.positionCount = 0;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Debug.Log(lineRenderer.positionCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
