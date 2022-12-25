using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBird : MonoBehaviour 
{
    public Rigidbody Rb;
    public GameObject Feathers;
    public GameObject FeatherExplosion;
    public BirdManager birdManager;
    public AudioClip BirdCollision;
    public AudioSource BirdPlayer;
    public float ReleaseTime = 0.5f;
    public float DestructionTime = 5f;


    public float force;

    void Start() {
        BirdPlayer = GetComponent<AudioSource>();
    }

    public void Release() {
        StartCoroutine(ReleaseCoroutine());
    }

    public void castSkill() {
        Rb.AddForce(transform.forward * 1000);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            GameObject feathers = Instantiate(Feathers, transform.position, Quaternion.identity);
            Destroy(feathers, 2);
            if (!BirdPlayer.isPlaying)
            {
                BirdPlayer.PlayOneShot(BirdCollision);
            }
        }
    }

    virtual public void CastSpell() {
        // 往前衝刺
        Rb.AddForce(transform.forward * 1000);
    }

    IEnumerator ReleaseCoroutine()
    {
        yield return new WaitForSeconds(ReleaseTime);

        Destroy(GetComponent<SpringJoint>());
        StartCoroutine(ExplodCoroutine());
    }

    IEnumerator ExplodCoroutine()
    {
        yield return new WaitForSeconds(DestructionTime);

        Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManagerV2.Instance.CheckGameStatus();
    }
}
