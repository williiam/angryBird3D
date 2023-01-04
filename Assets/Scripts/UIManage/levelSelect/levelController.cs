using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelController : MonoBehaviour
{
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public Sprite level2Lock;
    public Sprite level3Lock;
    public Sprite level4Lock;
    public Sprite level5Lock;
    public Sprite level6Lock;
    public Sprite level2Unlock;
    public Sprite level3Unlock;
    public Sprite level4Unlock;
    public Sprite level5Unlock;
    public Sprite level6Unlock;
    private GameObject bgm;
    // Start is called before the first frame update
    void Start()
    {
        // 非測試用拿掉下一行
        //PlayerPrefs.SetInt("levelUnlock", 5);
        int levelUnlock = PlayerPrefs.GetInt("levelUnlock", 0);
        if(levelUnlock == 1) {
            level2.GetComponent<Image>().sprite = level2Lock;
            level3.GetComponent<Image>().sprite = level3Lock;
            level4.GetComponent<Image>().sprite = level4Lock;
            level5.GetComponent<Image>().sprite = level5Lock;
        }
        else if(levelUnlock == 2) {
            level2.GetComponent<Image>().sprite = level2Unlock;
            level3.GetComponent<Image>().sprite = level3Lock;
            level4.GetComponent<Image>().sprite = level4Lock;
            level5.GetComponent<Image>().sprite = level5Lock;
        }
        else if(levelUnlock == 3) {
            level2.GetComponent<Image>().sprite = level2Unlock;
            level3.GetComponent<Image>().sprite = level3Unlock;
            level4.GetComponent<Image>().sprite = level4Lock;
            level5.GetComponent<Image>().sprite = level5Lock;
        }
        else if(levelUnlock == 4) {
            level2.GetComponent<Image>().sprite = level2Unlock;
            level3.GetComponent<Image>().sprite = level3Unlock;
            level4.GetComponent<Image>().sprite = level4Unlock;
            level5.GetComponent<Image>().sprite = level5Lock;
        }
        else if(levelUnlock == 5) {
            level2.GetComponent<Image>().sprite = level2Unlock;
            level3.GetComponent<Image>().sprite = level3Unlock;
            level4.GetComponent<Image>().sprite = level4Unlock;
            level5.GetComponent<Image>().sprite = level5Unlock;
        }
    }
}
