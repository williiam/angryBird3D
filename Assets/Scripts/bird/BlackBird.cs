using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : BaseBird
{
   public override void CastSpell(){
        // 使此鳥爆炸
        Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
   }

   // onClick
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    private void OnMouseDown()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if(bird!=null&&bird.GetType()== typeof(BlackBird)){
            return;
        }
        BirdManager.Instance.SetCurrentBird("black");
    }
}
