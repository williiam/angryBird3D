using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    void Start() {
         GetComponent<Button>().onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel() {
        int level = SceneManager.GetActiveScene().buildIndex;
        // 目前只有一關卡，直接當作retry
        SceneManager.LoadScene(level/*+1*/);
        Time.timeScale = 1;
    }
}