﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : BaseBird
{
   public BaseBird splitBird;
   public override void CastSpell(){
       //分裂
       Instantiate(splitBird, transform.position, transform.rotation);
       Instantiate(splitBird, transform.position, transform.rotation);
       Instantiate(splitBird, transform.position, transform.rotation);
   }

   // onClick
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    private void OnMouseDown()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if(bird!=null&&bird.GetType()== typeof(BlueBird)){
            return;
        }
        BirdManager.Instance.SetCurrentBird("blue");
    }
}