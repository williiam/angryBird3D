using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void Start() {
         GetComponent<Button>().onClick.AddListener(Retry);
    }

    public void Retry() {
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}