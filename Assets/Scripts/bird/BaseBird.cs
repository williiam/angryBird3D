using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBird : MonoBehaviour
{
    public GameObject skillBtn;
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

    void Start()
    {
        BirdPlayer = GetComponent<AudioSource>();
    }

    public void Release()
    {
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

    public void OnSkillBtnClick()
    {
        SkillBtnController.Instance.DisableSkillBtn();
        CastSpell();
    }

    virtual public void CastSpell()
    {
        // 往前衝刺
        Rb.AddForce(transform.forward * 1000);
    }

    protected void onBirdDestroy()
    {
        BirdManager.Instance.SetReady(true);
        Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
        Destroy(GetComponent<SpringJoint>());
        Destroy(gameObject);
        GameManagerV2.Instance.CheckGameStatus();
        SkillBtnController.Instance.EnableSkillBtn();
        ShootController.Instance.SetStage(0);
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
        onBirdDestroy();
    }

    // 點此鳥發出叫聲
    public void OnClick()
    {
        if (BirdPlayer.isPlaying)
        {
            BirdPlayer.Stop();
        }
        BirdPlayer.Play();
    }
}


