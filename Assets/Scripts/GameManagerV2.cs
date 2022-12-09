using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{

    public static GameManagerV2 Instance;
    public GameObject sp;
    public GameObject StillBird;
    public int remainingBirds = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        int level = SceneManager.GetActiveScene().buildIndex;
        // TODO: 播放遊戲音樂
        SetNewBird();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void CheckGameStatus() 
    {
        int remainingPigs = 0;
        // 獲得豬的數量
        GameObject[] pigs;
        pigs = GameObject.FindGameObjectsWithTag("Pig");
        remainingPigs = pigs.Length;
        // 如果沒有豬則遊戲通關
        if(remainingPigs == 0) {
            Time.timeScale = 0;
            Debug.Log("Passed ><");
            // TODO: 下一關的UI或是全部破關的UI
            // TODO: 停止遊戲音樂，播放通關音效
        }
        // 如果沒有鳥但還有豬則遊戲失敗
        if(remainingBirds == 0 && remainingPigs != 0) {
            Time.timeScale = 0;
            Debug.Log("GameOver ==");
            // TODO: 遊戲失敗及重新開始UI
            // TODO: 停止遊戲音樂，播放失敗音效
        }
    }

    public void SetNewBird()
    {
        // 先檢查遊戲狀態
        CheckGameStatus();
        remainingBirds--;
        if (remainingBirds >= 0)
        {
            sp.GetComponent<shootPointController>().setNewBird();
            // 刪除所有待命鳥
            foreach (StillBird stillBird in FindObjectsOfType<StillBird>())
            {
                Destroy(stillBird.gameObject);
            }
            // 重新生成待命鳥
            if (remainingBirds > 0)
            {
                for (int i = 0; i < remainingBirds; i++)
                {
                    GameObject stillBird = Instantiate(StillBird, new Vector3(0, 0, 0), Quaternion.identity);
                    stillBird.transform.Find("Bird Body").transform.position = new Vector3(-2.5f * (i + 1), 0, -3.19f);
                    if (i % 2 == 0)
                    {
                        stillBird.GetComponent<StillBird>().WaitForSeconds = 0.45f;
                    }
                }
            }
        }
    }
}