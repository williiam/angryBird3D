using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
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

    private void startcoroutine() {
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(LoadLevel1());
    }

    IEnumerator LoadLevel1() {
        yield return new WaitForSeconds(btnClickTime);
        bgm.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(2);
        yield return null;
    }
}
