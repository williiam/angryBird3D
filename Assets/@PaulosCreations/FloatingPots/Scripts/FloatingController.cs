using UnityEngine;
using System.Collections;

public class FloatingController : MonoBehaviour
{
    public AnimationCurve floatingAnimation;
    public float moveSpeed, rotationSpeed;
    public bool animatePots = true;

    private Transform potTF;
    private Vector3 wantedPosition, rotationVector = new Vector3(0,1,0), startPostion;
    private float wantedHeight, startHeight, evalAnimCurve;
    private Coroutine floatPotsCoroutine;

    // Use this for initialization
    void Start()
    {
        potTF = transform;
        wantedPosition = potTF.localPosition;
        startHeight = potTF.localPosition.y;

        if (animatePots)
            floatPotsCoroutine = StartCoroutine(FloatPotsAnimation());
    }

    private IEnumerator FloatPotsAnimation()
    {
        while (animatePots)
        {
            if (evalAnimCurve < 1)
                evalAnimCurve += moveSpeed * Time.deltaTime;
            else if (evalAnimCurve >= 1)
                evalAnimCurve = 0;

            wantedPosition[1] = startHeight + floatingAnimation.Evaluate(evalAnimCurve);

            potTF.localPosition = wantedPosition;

            if (rotationSpeed != 0)
                potTF.Rotate(rotationVector, Time.deltaTime * rotationSpeed);

            yield return new WaitForEndOfFrame();
        }
    }
}
