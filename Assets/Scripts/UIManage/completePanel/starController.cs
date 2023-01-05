using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starController : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;
    private float starRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        star1.transform.localScale = Vector3.zero;
        star2.transform.localScale = Vector3.zero;
        star3.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startcoroutine() {
        StartCoroutine(ShowStars());
    }

    IEnumerator ShowStars() {
        int score = GameManagerV2.Instance.score;
        int totalScore = GameManagerV2.Instance.totalScore;
        // TODO: 增加判斷幾顆星星的機制, star scale is 1.2, 0.84, 0
        // star1
        float timer = 0f;
        while(timer < 1f) {
            star1.transform.localScale = new Vector3(timer * 1.2f, timer * 0.84f , 0f);
            timer += Time.fixedUnscaledDeltaTime * starRate;
            yield return null;
        }

        // star2
        if(score > totalScore * 0.5f) {
            timer = 0f;
            while(timer < 1f) {
                star2.transform.localScale = new Vector3(timer * 1.2f, timer * 0.84f , 0f);
                timer += Time.fixedUnscaledDeltaTime * starRate;
                yield return null;
            }
        }

        // star3
        if(score > totalScore * 0.5f) {
            timer = 0f;
            while(timer < 1f) {
                star3.transform.localScale = new Vector3(timer * 1.2f, timer * 0.84f , 0f);
                timer += Time.fixedUnscaledDeltaTime * starRate;
                yield return null;
            }
        }
    }
}
