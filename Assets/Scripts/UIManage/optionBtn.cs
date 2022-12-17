using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionBtn : MonoBehaviour
{
    public GameObject gameMenu;
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    public GameObject gameManager;
    public AudioSource GMplayer;
    private float menuRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        btnPlayer = GetComponent<AudioSource>();
        GMplayer = gameManager.GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        this.transform.localScale = Vector3.zero;   // initial is 0.4, 2, 1
        // 暫停遊戲背景音
        GMplayer.Stop();
        // 播放按鍵聲
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(ShowGameMenu());
    }

    IEnumerator ShowGameMenu() {
        // 漸放大面板
        float timer = 0f;
        while(timer < 1f) {
            gameMenu.transform.localScale = new Vector3(timer * 0.3f, timer * 1.8f, 0f);
            timer += Time.fixedUnscaledDeltaTime * menuRate;
            yield return null;
        }
        // 遊戲暫停
        Time.timeScale = 0;
    }
}
