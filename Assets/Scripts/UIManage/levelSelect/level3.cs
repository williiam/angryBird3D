using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level3 : MonoBehaviour
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

    private void startcoroutine() {
        btnPlayer.PlayOneShot(btnClick);
        StartCoroutine(LoadLevel3());
    }

    IEnumerator LoadLevel3() {
        yield return new WaitForSeconds(btnClickTime);
        if(PlayerPrefs.GetInt("levelUnlock", 0) >= 3)
            SceneManager.LoadScene(4);
        yield return null;
    }
}