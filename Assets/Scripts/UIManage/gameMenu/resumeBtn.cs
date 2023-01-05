using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumeBtn : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject optionBtn;
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    public GameManagerV2 gameManager;
    public AudioSource GMplayer;
    private float menuRate = 3f;
    private float btnClickTime = 0.470f;
    // Start is called before the first frame update

    void Start()
    {
        GMplayer = gameManager.GetComponent<AudioSource>();
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        // 繼續播放遊戲背景音
        GMplayer.Play();
        // 播放按鍵聲
        btnPlayer.Stop();
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(HideGameMenu());
    }

    IEnumerator HideGameMenu() {
        Time.timeScale = 1;
        yield return new WaitForSeconds(btnClickTime);
        Time.timeScale = 0;
        // 漸縮小面板
        float timer = 0f;
        while(timer < 1f) {
            gameMenu.transform.localScale = new Vector3(0.3f - (timer * 0.3f), 1.8f - (timer * 1.8f) , 0f);
            timer += Time.fixedUnscaledDeltaTime * menuRate;
            yield return null;
        }
        // 遊戲繼續
        Time.timeScale = 1;
        // 顯示optionBtn
        optionBtn.transform.localScale = new Vector3(0.6f, 3f, 0f);   // initial is 0.6, 3, 1
    }
}
