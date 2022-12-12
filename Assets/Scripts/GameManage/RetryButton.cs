using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    void Start() {
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(Retry);
    }

    private void Retry() {
        // 播放按鍵聲
        btnPlayer.PlayOneShot(btnClick);
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}