using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starBtn : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    public GameObject speechBubble;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    private float btnClickTime = 0.470f;

    // Start is called before the first frame update
    void Start()
    {
        speechBubble.transform.localScale = Vector3.zero;
        star1.transform.localScale = Vector3.zero;
        star2.transform.localScale = Vector3.zero;
        star3.transform.localScale = Vector3.zero;
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        StartCoroutine(ToggleStars());
    }

    IEnumerator ToggleStars() {
        // 播放按鍵聲
        btnPlayer.PlayOneShot(btnClick);
        Time.timeScale = 1;
        yield return new WaitForSeconds(btnClickTime);
        Time.timeScale = 0;
        // 打開對話框
        if(speechBubble.transform.localScale == Vector3.zero) {
            speechBubble.transform.localScale = new Vector3(4.2998f, 0.51252f, 0f);
            int totalScore = GameManagerV2.Instance.GetTotalScore();
            int score = GameManagerV2.Instance.GetScore();
            if(score >= totalScore * 0.8f) {
                star1.transform.localScale = new Vector3(0.3488534f, 0.585343f, 0f);
                star2.transform.localScale = new Vector3(0.3488534f, 0.585343f, 0f);
                star3.transform.localScale = new Vector3(0.3488534f, 0.585343f, 0f);
            } else if(score >= totalScore * 0.5f) {
                star1.transform.localScale = new Vector3(0.3488534f, 0.585343f, 0f);
                star2.transform.localScale = new Vector3(0.3488534f, 0.585343f, 0f);
                star3.transform.localScale = Vector3.zero;
            } else {
                star1.transform.localScale = new Vector3(0.3488534f, 0.585343f, 0f);
                star2.transform.localScale = Vector3.zero;
                star3.transform.localScale = Vector3.zero;
            }
        } else {
            // 關閉對話框
            speechBubble.transform.localScale = Vector3.zero;
        }
    }
}