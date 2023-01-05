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
        Vector3 velocity = Rb.velocity;
        Rb.AddForce(velocity * 200);
   }
}
