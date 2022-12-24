using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldBird : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject Feathers;
    public GameObject FeatherExplosion;
    public BirdManager birdManager;
    /*
    public AudioClip Slingshot;
    public AudioClip SlingshotRelease;
    public AudioClip Flying;
    */
    public AudioClip BirdCollision;
    private AudioSource BirdPlayer;
    public float ReleaseTime = 0.5f;
    public float DestructionTime = 5f;
    private bool _isPressed;
    private bool _isFired;

    public float force;

    void Start() {
        BirdPlayer = GetComponent<AudioSource>();
    }

    public void castSkill() {
        Rb.AddForce(transform.forward * 1000);
    }

    // void FixedUpdate()
    // {
    //     if (_isPressed && !_isFired)
    //     {
    //         Vector3 mousePosition = Input.mousePosition;
    //         Vector3 worldPosition = Camera.main.ScreenToWorldPoint(
    //             new Vector3(mousePosition.x, mousePosition.y, force)
    //         );
    //         if (worldPosition.y >= 0.2f && worldPosition.y <= 8f)
    //         {
    //             Rb.position = worldPosition;
    //         }
    //     }
    // }

    // void OnMouseDown()
    // {
    //     if (_isFired)
    //     {
    //         return;
    //     }

    //     _isPressed = true;
    //     Rb.isKinematic = true;
    //     BirdPlayer.PlayOneShot(Slingshot);
    // }

    // void OnMouseUp()
    // {
    //     if (_isFired)
    //     {
    //         return;
    //     }

    //     _isPressed = false;
    //     Rb.isKinematic = false;
    //     // GetComponent<TrailRenderer>().enabled = true;
    //     _isFired = true;
    //     BirdPlayer.PlayOneShot(SlingshotRelease);
    //     BirdPlayer.PlayOneShot(Flying);
    //     StartCoroutine(Release());
    // }

    // public void Shoot() {
    //     Debug.Log("123");
    // }

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

    // IEnumerator Release()
    // {
    //     yield return new WaitForSeconds(ReleaseTime);

    //     Destroy(GetComponent<SpringJoint>());
    //     StartCoroutine(Explode());
    // }

    // IEnumerator Explode()
    // {
    //     yield return new WaitForSeconds(DestructionTime);

    //     GameManagerV2.Instance.SetNewBird();
    //     // GameManagerV2.Instance.BirdDestroy.Play();
    //     Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
    //     Destroy(gameObject);
    // }
    virtual public void CastSpell() {
        Debug.Log("123");
    }
}
