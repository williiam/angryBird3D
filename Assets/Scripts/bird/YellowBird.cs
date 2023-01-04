using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : BaseBird
{
    private void Awake()
    {
        birdType = "yellow";
    }
    public override void CastSpell(){
        Rb.AddForce(transform.forward * 1000);
   }

   // onClick
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    private void OnMouseDown()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if(bird!=null&&bird.GetType()== typeof(YellowBird)){
            return;
        }
        BirdManager.Instance.SetCurrentBird("yellow");
    }
}
