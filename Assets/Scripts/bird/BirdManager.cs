using System.Collections;
using UnityEngine;

public class BirdManager : MonoBehaviour
{

    public static BirdManager Instance;
    private BaseBird currentBird;

    public BaseBird redBird;
    public BaseBird yellowBird;
    public BaseBird blueBird;
    public BaseBird blackBird;
    public BaseBird pinkBird;
    private bool Ready;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Ready = true;
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
        if(Ready) {
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
        switch(type)
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

    public void setReady(bool val) {
        Ready = val;
    }

}
