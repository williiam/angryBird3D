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
        
        this.transform.localScale = new Vector3(3f, 3f, 3f);
        
        Rb.mass*=3;
   }
}
