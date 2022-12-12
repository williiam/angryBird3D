using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerV2 : MonoBehaviour
{

    public static GameManagerV2 Instance;
    public GameObject sp;
    public GameObject StillBird;
    public GameObject completePanel;
    public GameObject failedPanel;
    private AudioSource GMplayer;
    public AudioClip levelStart;
    public AudioClip levelClear;
    public AudioClip levelComplete;
    public AudioClip levelUnclear;
    public AudioClip levelFailed;
    public int remainingBirds = 3;
    public int level;
    public float panelRate = 3f;
    public bool gameStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // 獲得當前關卡index
        level = SceneManager.GetActiveScene().buildIndex;
        
        // 播放遊戲音樂
        GMplayer = GetComponent<AudioSource>();
        GMplayer.Play();

        // 設置遊戲狀態為進行中
        gameStatus = true;

        // 設置panel的scale為0
        completePanel.transform.localScale = Vector3.zero;
        failedPanel.transform.localScale = Vector3.zero;

        // 設置待命鳥
        SetNewBird();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: 分數系統
        // TODO: 偵測全局靜止才setBird, 若有camera視角帶開則不必
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
            gameStatus = false;
            // 停止遊戲音樂，播放通關音效
            GMplayer.Stop();
            GMplayer.PlayOneShot(levelClear);
            Invoke("LevelComplete", 5.112f);    // levelClear is 5.112sec
        }

        // 如果沒有鳥但還有豬則遊戲失敗
        if(remainingBirds == 0 && remainingPigs != 0) {
            gameStatus = false;
            // 停止遊戲音樂，播放失敗音效
            GMplayer.Stop();
            GMplayer.PlayOneShot(levelUnclear); // levelUnclear is 4.716sec
            Invoke("LevelFailed", 4.716f);
        }
    }

    private void LevelComplete() {
        // 遊戲完成，顯示遊戲完成面板
        StartCoroutine(ShowPanel(completePanel));
        GMplayer.PlayOneShot(levelComplete);
    }

    private void LevelFailed() {
        // 遊戲失敗，顯示遊戲失敗面板
        StartCoroutine(ShowPanel(failedPanel));
        GMplayer.PlayOneShot(levelFailed);
    }

    IEnumerator ShowPanel(GameObject panel) {
        // 漸放大面板
        float timer = 0f;
        while(timer < 1f) {
            panel.transform.localScale = new Vector3(timer, timer, 0);
            timer += Time.deltaTime * panelRate;
            yield return null;
        }
        // 遊戲暫停
        Time.timeScale = 0;
    }

    IEnumerator HidePanel(GameObject panel) {
        // 漸縮小面板
        float timer = 0f;
        while(timer < 1f) {
            panel.transform.localScale = new Vector3(1f - timer, 1f - timer, 0);
            timer += Time.deltaTime * panelRate;
            yield return null;
        }
        // 遊戲暫停
        Time.timeScale = 0;
    }

    public void SetNewBird()
    {
        // 先檢查遊戲狀態,若非進行中則return
        CheckGameStatus();
        if(!gameStatus)
            return;

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