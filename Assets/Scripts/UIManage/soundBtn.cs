using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundBtn : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    public Sprite soundOn;
    public Sprite soundOff;
    private float btnClickTime = 0.261f;
    // public GameObject startBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        // 遊戲開始時聲音為開啟
        AudioListener.volume = 1;
        this.GetComponent<Image>().sprite = soundOn;
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        StartCoroutine(toggleMute());
    }

    IEnumerator toggleMute() {
        if(AudioListener.volume == 0) {
            // 播放按鍵聲，並開啟聲音
            AudioListener.volume = 1;
            this.GetComponent<Image>().sprite = soundOn;
            // 播放按鍵聲
            btnPlayer.PlayOneShot(btnClick);
            Time.timeScale = 1;
            yield return new WaitForSeconds(btnClickTime);
            Time.timeScale = 0;
        } else {
            // 關閉聲音
            AudioListener.volume = 0;
            this.GetComponent<Image>().sprite = soundOff;
        }
    }
}
