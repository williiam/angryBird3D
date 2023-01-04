using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBtn : MonoBehaviour
{
    public AudioClip btnClick;
    public AudioSource btnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        btnPlayer = GetComponent<AudioSource>();
        GetComponent<Button>().onClick.AddListener(TriggerSkills);
    }

    private void TriggerSkills(){
        // 播放按鍵聲
        btnPlayer.PlayOneShot(btnClick);
        int stage = ShootController.Instance.GetStage();
        if(stage == 0 || stage == 1) {
            return;
        }
        BirdManager.Instance.CastSpell();
    }
}

