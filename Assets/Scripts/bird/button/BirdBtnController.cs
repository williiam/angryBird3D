using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdBtnController : MonoBehaviour
{

    public static BirdBtnController Instance;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRedClick()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if (bird != null && bird.GetType() == typeof(RedBird))
        {
            return;
        }
        BirdManager.Instance.SetCurrentBird("red");
    }
    public void OnYellowClick()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if (bird != null && bird.GetType() == typeof(YellowBird))
        {
            return;
        }
        BirdManager.Instance.SetCurrentBird("yellow");
    }
    public void OnBlueClick()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if (bird != null && bird.GetType() == typeof(BlueBird))
        {
            return;
        }
        BirdManager.Instance.SetCurrentBird("blue");
    }
    public void OnBlackClick()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if (bird != null && bird.GetType() == typeof(BlackBird))
        {
            return;
        }

        BirdManager.Instance.SetCurrentBird("black");
    }
}
