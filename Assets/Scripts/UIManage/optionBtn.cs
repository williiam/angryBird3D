using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionBtn : MonoBehaviour
{
    public GameObject gameMenu;
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    public GameManagerV2 gameManager;
    public AudioSource GMplayer;
    private float menuRate = 1f;
    private void setGameManagerV2()
    {
        // if game is null
        gameManager = GameManagerV2.Instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        setGameManagerV2();
        btnPlayer = GetComponent<AudioSource>();
        GMplayer = gameManager.GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        setGameManagerV2();
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
