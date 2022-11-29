using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void ResetLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene($"Level {level + 1}");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene($"Level 1");
    }
}
