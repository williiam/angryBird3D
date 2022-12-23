using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBtn : MonoBehaviour
{

    public Bird curShootingBird;
    public void onClick(){
        // 使當前飛行鳥放招
        curShootingBird = GetComponent<Bird>();
        curShootingBird.castSkill();
    }
}
