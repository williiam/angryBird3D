using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : BaseBird
{
   public SplitBlueBird splitBird;
    private void Awake()
    {
        birdType = "blue";
    }

    public override void CastSpell(){

        Collider originalCollider = GetComponent<Collider>();

        // 原鳥移動方向
        Vector3 originalVelocity = Rb.velocity*2;
    
        Quaternion spawnRot = Quaternion.identity;
        
       // 往上分裂
        Vector3 spawnPos = transform.position + Vector3.up;
        SplitBlueBird upBird = Instantiate(splitBird, spawnPos, spawnRot);
        Collider upCollider = upBird.GetComponent<Collider>();
        Physics.IgnoreCollision(originalCollider, upCollider, true);
        upBird.Rb.velocity = originalVelocity + Vector3.up * 5;

        Debug.Log("BlueBird CastSpell");

        // Instantiate prefab down
        spawnPos = transform.position + Vector3.down;
        SplitBlueBird downBird = Instantiate(splitBird, spawnPos, spawnRot);
        Collider downCollider = downBird.GetComponent<Collider>();
        Physics.IgnoreCollision(originalCollider, downCollider, true);
        downBird.Rb.velocity = originalVelocity + Vector3.down * 5;

        // Instantiate prefab left
        spawnPos = transform.position + Vector3.left;
        SplitBlueBird leftBird = Instantiate(splitBird, spawnPos, spawnRot);
        Collider leftCollider = leftBird.GetComponent<Collider>();
        Physics.IgnoreCollision(originalCollider, leftCollider, true);
        leftBird.Rb.velocity = originalVelocity + Vector3.left * 5;

        // Instantiate prefab right
        spawnPos = transform.position + Vector3.right;
        SplitBlueBird rightBird = Instantiate(splitBird, spawnPos, spawnRot);
        Collider rightCollider = rightBird.GetComponent<Collider>();
        Physics.IgnoreCollision(originalCollider, rightCollider, true);
        rightBird.Rb.velocity = originalVelocity + Vector3.right * 5;
   }

    public override void OnCollisionEnter(Collision collision)
    {
        GameObject feathers = Instantiate(Feathers, transform.position, Quaternion.identity);
        Destroy(feathers, 2);
        if (!BirdPlayer.isPlaying)
        {
            BirdPlayer.PlayOneShot(BirdCollision);
        }
    }
}
