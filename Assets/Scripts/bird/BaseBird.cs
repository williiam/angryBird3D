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
    public string birdType = "base";
    public float ReleaseTime = 0.5f;
    public float DestructionTime = 5f;
    public float force;
    public bool spellIsCasted = false;
   
    void Start() {
        BirdPlayer = GetComponent<AudioSource>();
    }

    public void Release() {
        StartCoroutine(ReleaseCoroutine());
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            GameObject feathers = Instantiate(Feathers, transform.position, Quaternion.identity);
            Destroy(feathers, 2);
            GameManagerV2.Instance.setCameraStatus(3);
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

    public void updateIsCastSpell() {
        if (Input.GetMouseButtonDown(0) && !spellIsCasted) {
            CastSpell();
            spellIsCasted = true;
        }
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
        BirdManager.Instance.SetReady(true);
        Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManagerV2.Instance.CheckGameStatus();
    }
}
