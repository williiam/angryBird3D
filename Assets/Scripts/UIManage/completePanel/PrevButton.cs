using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrevButton : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    private float btnClickTime = 0.261f;

    void Start() {
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(startcoroutine);
    }

    private void startcoroutine() {
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(LoadPrevLevel());
    }

    IEnumerator LoadPrevLevel() {
        Time.timeScale = 1;
        yield return new WaitForSeconds(btnClickTime);
        Time.timeScale = 0;

        int level = SceneManager.GetActiveScene().buildIndex;
        // 回到上一關
        SceneManager.LoadScene(level - 1);
        Time.timeScale = 1;
    }
}
