using System.Collections;
using UnityEngine;

public class BirdManager : MonoBehaviour
{

    public static BirdManager Instance;
    public BaseBird currentBird;

    public BaseBird redBird;
    public BaseBird yellowBird;
    public BaseBird blueBird;
    public BaseBird blackBird;
    public BaseBird pinkBird;

    void Awake()
    {
    }
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public BaseBird GetCurrentBird()
    {
        return currentBird;
    }

    public void SetCurrentBird(string type)
    {
        // 生成一隻當前種類的待射鳥
        Destroy(currentBird);
        BaseBird bird = (BaseBird)getBirdByType(type);
        currentBird = Instantiate(bird, transform.position, Quaternion.identity);
    }

    public void CastSpell()
    {
        currentBird.CastSpell();
    }

    // onClick event

    private BaseBird getBirdByType(string type)
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

}
