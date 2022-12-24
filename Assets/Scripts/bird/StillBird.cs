using System.Collections;
using UnityEngine;

public class StillBird : MonoBehaviour
{
    public float WaitForSeconds;

    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(WaitForSeconds);

        GetComponent<Animator>().enabled = true;
    }

    // onClick event
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    // birdManager

}
