using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playBtn : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    private float btnClickTime = 0.261f;
    // Start is called before the first frame update
    void Start()
    {
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startcoroutine() {
        // 播放按鍵聲
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene() {
        //yield return new WaitForSeconds(btnClickTime);
        // load game scene
        SceneManager.LoadScene(1);
        yield return null;
    }
}
