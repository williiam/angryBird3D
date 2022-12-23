using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homeBtn : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    private float btnClickTime = 0.261f;
    private GameObject bgm;
    // Start is called before the first frame update
    void Start()
    {
        btnPlayer = GetComponent<AudioSource>();
        bgm = GameObject.FindWithTag("bgm");
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        // 播放按鍵聲
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(BackToHome());
    }

    IEnumerator BackToHome() {
        // 先播放按鍵聲再load new scene
        Time.timeScale = 1;
        yield return new WaitForSeconds(btnClickTime);
        Time.timeScale = 0;
        
        // 改成home scene
        SceneManager.LoadScene(1);
        bgm.GetComponent<AudioSource>().Play();
        // 遊戲繼續
        Time.timeScale = 1;
        yield return null;
    }
}
