using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;

// TODO: 分數系統
// TODO: 偵測全局靜止才setBird
// TODO: Camera三狀態

public class GameManagerV2 : MonoBehaviour
{
    public static GameManagerV2 Instance;
    // 關卡設定
    //public SceneSettings sceneSettings;
    // 發射相關
    public GameObject hook;
    public GameObject StillBird;
    // UI相關
    public GameObject completePanel;
    public GameObject failedPanel;
    public GameObject optionBtn;
    public GameObject skillBtn;
    public Text scoreText;
    // 音效相關
    private AudioSource GMplayer;
    public AudioClip levelStart;
    public AudioClip levelClear;
    public AudioClip levelComplete;
    public AudioClip levelUnclear;
    public AudioClip levelFailed;
    // 遊戲變數
    public int score = 0;
    public int totalScore = 0;
    public int level;
    public float panelRate = 3f;
    private int cameraStatus = 0; 
    // 0 鳥不在彈弓上且未發射
    // 1 鳥在彈弓上但還沒射
    // 2 鳥已經發射且未落地
    // 3 鳥落地(3秒後變為0)
    public bool gameStatus;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // 獲得當前關卡index
        level = SceneManager.GetActiveScene().buildIndex;
        
        // 禁用complete panel和failed panel
        completePanel.SetActive(false);
        failedPanel.SetActive(false);

        // 播放遊戲音樂
        GMplayer = GetComponent<AudioSource>();
        GMplayer.Play();

        // 設置遊戲狀態為true
        gameStatus = true;

        // 設置camera狀態為0
        cameraStatus = 0;

        // 設置panel的scale為0
        completePanel.transform.localScale = Vector3.zero;
        failedPanel.transform.localScale = Vector3.zero;

        // 設置待命鳥
        //BirdManager.Instance.InitBirds(sceneSettings);

        // 先計算出關卡總分
        int pigQuan = GameObject.FindGameObjectsWithTag("Pig").Length;
        totalScore += pigQuan * 10000;
        totalScore += BirdManager.Instance.RemainBirds * 5000;
        // TODO: totalScore += 加分物件數量 * 加分物件得分 
    }

    public void CheckGameStatus() 
    {
        int remainingPigs = 0;

        // 獲得豬的數量
        GameObject[] pigs;
        pigs = GameObject.FindGameObjectsWithTag("Pig");
        remainingPigs = pigs.Length;
        
        // 如果沒有豬則遊戲通關
        if(remainingPigs == 0) {
            gameStatus = false;
            // 剩餘的鳥每隻+5000分
            for(int i = 0; i < BirdManager.Instance.RemainBirds; ++i) {
                AddScore(5000);
            }
            // 停止遊戲音樂，播放通關音效
            GMplayer.Stop();
            GMplayer.PlayOneShot(levelClear);
            // 隱藏Btn
            optionBtn.transform.localScale = Vector3.zero;
            skillBtn.transform.localScale = Vector3.zero;
            Invoke("LevelComplete", 5.112f);    // levelClear is 5.112sec
        }
        else if(BirdManager.Instance.RemainBirds == 0 && remainingPigs != 0) {
            // 如果沒有鳥但還有豬則遊戲失敗
            gameStatus = false;
            // 停止遊戲音樂，播放失敗音效
            GMplayer.Stop();
            GMplayer.PlayOneShot(levelUnclear); // levelUnclear is 4.716sec
            // 隱藏Btn
            optionBtn.transform.localScale = Vector3.zero;
            skillBtn.transform.localScale = Vector3.zero;
            Invoke("LevelFailed", 4.716f);
        }
        else {
            // 如果遊戲未結束，偵測到鳥靜止後開始偵測全局豬和建築
            // 等到velocity都等於0才return
        
            GameObject[] buildings;
            buildings = GameObject.FindGameObjectsWithTag("Building");
            //GameObject bird = GameObject.FindGameObjectWithTag("Bird"); // 此處鳥的tag要與still bird有區別
        
            // 偵測鳥是否靜止，目前不需要，因為鳥destroy之後才呼叫此函式
            /*
            while(true) {
                if(bird.GetComponent<Rigidbody>().velocity == Vector3.zero)
                    break;
            }
            */

            // 開始偵測建築跟豬是否靜止
            while(true) {
                bool canBreak = true;
                // 更新pigs
                pigs = GameObject.FindGameObjectsWithTag("Pig");
                // 更新buildings
                buildings = GameObject.FindGameObjectsWithTag("Building");
                int length = pigs.Length > buildings.Length ? pigs.Length : buildings.Length;
                for(int i = 0; i < length; ++i) {
                    if((length < pigs.Length && pigs[i].GetComponent<Rigidbody>().velocity != Vector3.zero)
                        || (length < buildings.Length && buildings[i].GetComponent<Rigidbody>().velocity != Vector3.zero)) {
                        canBreak = false;
                        break;
                    }
                }
                if(canBreak) {
                    BirdManager.Instance.SetReady(true);
                    break;
                }
            }
        }
    }

    public void setCameraStatus(int n) {
        if(n > 3 || n < 0) {
            Debug.Log("param doesn't corresponding");
        }
        cameraStatus = n;
    }

    public int getCameraStatus() {
        return cameraStatus;
    } 

    public void AddScore(int n) {
        score += n;
        scoreText.text = "SCORE: " + score;
        Debug.Log(n);
    }

    public int GetScore() {
        return score;
    }

    public int GetTotalScore() {
        return totalScore;
    }

    private void LevelComplete() {
        // 遊戲完成，顯示遊戲完成面板
        StartCoroutine(ShowPanel(completePanel));
        GMplayer.PlayOneShot(levelComplete);
        PlayerPrefs.SetInt("levelUnlock", level);
    }

    private void LevelFailed() {
        // 遊戲失敗，顯示遊戲失敗面板
        StartCoroutine(ShowPanel(failedPanel));
        GMplayer.PlayOneShot(levelFailed);
    }

    IEnumerator ShowPanel(GameObject panel) {
        // 隱藏scoreText
        scoreText.transform.localScale = Vector3.zero;
        // enable panel
        panel.SetActive(true);
        // 漸放大面板
        float timer = 0f;
        while(timer < 1f) {
            panel.transform.localScale = new Vector3(timer, timer * 1.5f, 0);
            timer += Time.deltaTime * panelRate;
            yield return null;
        }
        // 如果panel是completePanel,則觸發星星的動畫
        if(panel.GetComponent<starController>()) {
            panel.GetComponent<starController>().startcoroutine();
        }
        // 否則觸發豬的動畫
        else if(panel.GetComponent<pigController>()) {
            panel.GetComponent<pigController>().startcoroutine();
        }
        // 遊戲暫停
        Time.timeScale = 0;
    }

    IEnumerator HidePanel(GameObject panel) {
        // 漸縮小面板
        float timer = 0f;
        while(timer < 1f) {
            panel.transform.localScale = new Vector3(1f - timer, 1.5f - (timer * 1.5f), 0);
            timer += Time.deltaTime * panelRate;
            yield return null;
        }
        panel.SetActive(false);
        // 遊戲暫停
        Time.timeScale = 0;
    }
}