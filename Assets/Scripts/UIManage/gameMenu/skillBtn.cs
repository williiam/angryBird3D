using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillBtn : MonoBehaviour
{
    public void onClick(){
        // 使當前飛行鳥放招
        GameObject curShootingBird = GetComponent<Bird>();
        curShootingBird.castSkill();
    }
}
