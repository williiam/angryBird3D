using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : BaseBird
{


   public void CastSpell(){
        Rb.AddForce(transform.forward * 1000);
   }

   // onClick
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    private void OnMouseDown()
    {
        Debug.Log("Mouse Click Detected");
        BirdManager.Instance.SetCurrentBird("red");
    }
}
