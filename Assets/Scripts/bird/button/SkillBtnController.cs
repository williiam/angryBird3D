using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtnController : MonoBehaviour
{

    public static SkillBtnController Instance;
    public Button skillBtn;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        skillBtn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSkillBtnClick()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if (bird != null)
        {
            bird.OnSkillBtnClick();
        }
    }
    public void EnableSkillBtn()
    {
        skillBtn.interactable = true;
        skillBtn.gameObject.SetActive(true);
    }
    public void DisableSkillBtn()
    {
        skillBtn.interactable = false;
        // 引藏技能按鈕
        skillBtn.gameObject.SetActive(false);
    }
}
