using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBird : BaseBird
{
    private void Awake()
    {
        birdType = "red";
    }
    public override void CastSpell(){
        // Rb.AddForce(transform.forward * 1000);
        updateIsCastSpell();
        this.transform.localScale = new Vector3(3f, 3f, 3f);
   }

   // onClick
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    private void OnMouseDown()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if(bird!=null&&bird.GetType()== typeof(RedBird)){
            return;
        }
        BirdManager.Instance.SetCurrentBird("red");
    }
}
