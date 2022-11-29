using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer Line;
    public GameObject Bird;
    public GameObject LeftSide;
    public GameObject RightSide;
    public GameObject Hook;

    void Start()
    {
        Line.positionCount = 5;
    }

    void Update()
    {
        Line.SetPosition(0, LeftSide.transform.position);
        if (Bird == null || Bird.GetComponent<SpringJoint>() == null)
        {
            Line.SetPosition(1, Hook.transform.position);
            Line.SetPosition(2, Hook.transform.position);
            Line.SetPosition(3, Hook.transform.position);
        }
        else
        {
            Line.SetPosition(1, new Vector3(Bird.transform.position.x - 0.5f, Bird.transform.position.y, Bird.transform.position.z + 1f));
            Line.SetPosition(2, new Vector3(Bird.transform.position.x, Bird.transform.position.y, Bird.transform.position.z - 1f));
            Line.SetPosition(3, new Vector3(Bird.transform.position.x + 0.5f, Bird.transform.position.y, Bird.transform.position.z + 1f));
        }
        Line.SetPosition(4, RightSide.transform.position);
    }
}