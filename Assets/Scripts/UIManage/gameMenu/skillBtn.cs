using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBtn : MonoBehaviour
{
    public Bird curShootingBird;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void onClick(){
        // 使當前飛行鳥放招
        Bird curShootingBird = (Bird)FindObjectOfType(typeof(Bird));
        if(curShootingBird == null) {
            Debug.Log("No bird found!");
            return;
        }
        else{
            curShootingBird.castSkill();
        }
    }
}

