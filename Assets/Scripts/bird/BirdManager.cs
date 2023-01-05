using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;
using UnityEngine.UI;

public class BirdManager : MonoBehaviour
{

    public static BirdManager Instance;
    private BaseBird currentBird;

    public BaseBird redBird;
    public BaseBird yellowBird;
    public BaseBird blueBird;
    public BaseBird blackBird;
    public BaseBird pinkBird;

    public int remainRedBirds = 1;
    public int remainYellowBirds = 1;
    public int remainBLueBirds = 1;
    public int remainBlackBirds = 1;

    // remainBirds btn
    public GameObject remainRedBirdsBtn;
    public GameObject remainYellowBirdsBtn;
    public GameObject remainBlueBirdsBtn;
    public GameObject remainBlackBirdsBtn;

    // remainBirds text
    public Text remainRedBirdsText;
    public Text remainYellowBirdsText;
    public Text remainBlueBirdsText;
    public Text remainBlackBirdsText;

    //private int remainBirds;
    private bool Ready;

    public int RemainBirds
    {
        get
        {
            int result = remainRedBirds + remainYellowBirds + remainBLueBirds + remainBlackBirds;
            Debug.Log("remainRedBirds: " + result);
            return result;
        }
        set { }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // 初始化remainBirdsText
        remainRedBirdsText = remainRedBirdsBtn.GetComponentInChildren<Text>();
        remainYellowBirdsText = remainYellowBirdsBtn.GetComponentInChildren<Text>();
        remainBlueBirdsText = remainBlueBirdsBtn.GetComponentInChildren<Text>();
        remainBlackBirdsText = remainBlackBirdsBtn.GetComponentInChildren<Text>();

    }

    void Start()
    {
        Ready = true;

        // 依照當前關卡設定不同數量的鳥
        int level = SceneManager.GetActiveScene().buildIndex - 1;
        Debug.Log(level);
        UpdateRemainBirdsText();
    }

    public void InitBirds()
    {
        // 取得當前scene index
        int level = SceneManager.GetActiveScene().buildIndex - 1;
        // 依照當前關卡設定不同數量的鳥
        switch (level)
        {
            case 0:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            case 1:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            case 2:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            case 3:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            case 4:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            case 5:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            case 6:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
            default:
                remainRedBirds = 1;
                remainYellowBirds = 1;
                remainBLueBirds = 1;
                remainBlackBirds = 1;
                break;
        }
    }

    // 發射一隻鳥，將該鳥種類-1，並將該鳥種類的鳥數量text更新   
    public void OnBirdShoot()
    {
        if (Ready)
        {
            Ready = false;
            switch (currentBird.birdType)
            {
                case "red":
                    remainRedBirds--;
                    UpdateRemainBirdsText();
                    break;
                case "yellow":
                    remainYellowBirds--;
                    UpdateRemainBirdsText();
                    break;
                case "blue":
                    remainBLueBirds--;
                    UpdateRemainBirdsText();
                    break;
                case "black":
                    remainBlackBirds--;
                    UpdateRemainBirdsText();
                    break;
            }
        }
    }

    // 更新全部鳥的剩餘數量(用字串模板)
    public void UpdateRemainBirdsText()
    {
        remainRedBirdsText.text = $"X{remainRedBirds}";
        remainYellowBirdsText.text = $"X{remainYellowBirds}";
        remainBlueBirdsText.text = $"X{remainBLueBirds}";
        remainBlackBirdsText.text = $"X{remainBlackBirds}";
        
        // 若紅鳥歸0,將紅鳥按鈕設為不可用
        if (remainRedBirds <= 0)
        {
            getBirdBtn("red").GetComponent<Button>().interactable = false;
        }
        else
        {
            getBirdBtn("red").GetComponent<Button>().interactable = true;
        }

        if (remainYellowBirds <= 0)
        {
            getBirdBtn("yellow").GetComponent<Button>().interactable = false;
        }
        else
        {
            getBirdBtn("yellow").GetComponent<Button>().interactable = true;
        }

        if (remainBLueBirds <= 0)
        {
            getBirdBtn("blue").GetComponent<Button>().interactable = false;
        }
        else
        {
            getBirdBtn("blue").GetComponent<Button>().interactable = true;
        }
        if (remainBlackBirds <= 0)
        {
            getBirdBtn("black").GetComponent<Button>().interactable = false;
        }
        else
        {
            getBirdBtn("black").GetComponent<Button>().interactable = true;
        }
    }

    public BaseBird GetCurrentBird()
    {
        return currentBird;
    }

    public void SetCurrentBird(string type)
    {
        Ready = true;
        if (currentBird != null)
        {
            Destroy(currentBird.gameObject);
        }
        if (Ready)
        {
            ShootController.Instance.SetStage(0);
            BaseBird bird = (BaseBird)getBirdPrefab(type);
            // 生成一隻鳥，使其在彈弓上
            currentBird = Instantiate(bird, transform.position, Quaternion.identity);
            currentBird.tag = "Bird";
        }
    }

    public void CastSpell()
    {
        currentBird.CastSpell();
    }

    // onClick event

    private BaseBird getBirdPrefab(string type)
    {
        switch (type)
        {
            case "red":
                return redBird;
            case "yellow":
                return yellowBird;
            case "blue":
                return blueBird;
            case "black":
                return blackBird;
            case "pink":
                return pinkBird;
            default:
                return null;
        }
    }

    private GameObject getBirdBtn(string type)
    {
        switch (type)
        {
            case "red":
                return remainRedBirdsBtn;
            case "yellow":
                return remainYellowBirdsBtn;
            case "blue":
                return remainBlueBirdsBtn;
            case "black":
                return remainBlackBirdsBtn;
            default:
                return null;
        }
    }
    public void SetReady(bool val)
    {
        Ready = val;
    }

}
