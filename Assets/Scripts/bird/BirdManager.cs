using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;
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
            return remainRedBirds + remainYellowBirds + remainBLueBirds + remainBlackBirds;
        }
        set {  }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Ready = true;

        // 依照當前關卡設定不同數量的鳥
        int level = SceneManager.GetActiveScene().buildIndex - 1;
        Debug.Log(level);
        //switch (level)
        //{
        //    case 1:
        //        GameManagerV2.Instance.SetRemainingBirds(3);
        //        break;
        //    case 2:
        //        GameManagerV2.Instance.SetRemainingBirds(3);
        //        break;
        //    case 3:
        //        GameManagerV2.Instance.SetRemainingBirds(3);
        //        break;
        //    case 4:
        //        GameManagerV2.Instance.SetRemainingBirds(3);
        //        break;
        //    case 5:
        //        GameManagerV2.Instance.SetRemainingBirds(3);
        //        break;
        //    case 6:
        //        GameManagerV2.Instance.SetRemainingBirds(3);
        //        break;
        //}
    }

    //public void InitBirds(SceneSettings settings)
    //{

    //}

    // 發射一隻鳥，將該鳥種類-1，並將該鳥種類的鳥數量text更新   
    public void OnBirdShoot(BaseBird bird)
    {
        if (Ready)
        {
            currentBird = bird;
            Ready = false;
            switch (bird.birdType)
            {
                case "red":
                    remainRedBirds--;
                    remainRedBirdsText.text = remainRedBirds.ToString();
                    break;
                case "yellow":
                    remainYellowBirds--;
                    remainYellowBirdsText.text = remainYellowBirds.ToString();
                    break;
                case "blue":
                    remainBLueBirds--;
                    remainBlueBirdsText.text = remainBLueBirds.ToString();
                    break;
                case "black":
                    remainBlackBirds--;
                    remainBlackBirdsText.text = remainBlackBirds.ToString();
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
    }


    public BaseBird GetCurrentBird()
    {
        return currentBird;
    }

    public void SetCurrentBird(string type)
    {
        /*
        if (currentBird != null)
        {
            Destroy(currentBird.gameObject);
        }
        */
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

    public void setReady(bool val)
    {
        Ready = val;
    }

}
