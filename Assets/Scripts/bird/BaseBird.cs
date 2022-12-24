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
    private AudioSource BirdPlayer;

    public float force;

    void Start() {
        BirdPlayer = GetComponent<AudioSource>();
    }

    public void castSkill() {
        Rb.AddForce(transform.forward * 1000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<TrailRenderer>().enabled = false;
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
        Debug.Log("123");
    }
}
