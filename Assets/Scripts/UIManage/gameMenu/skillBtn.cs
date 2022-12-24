using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void onClick(){
        int stage = ShootController.Instance.GetStage();
        if(stage == 0 || stage == 1) {
            return;
        }
        BirdManager.Instance.CastSpell();
    }
}

