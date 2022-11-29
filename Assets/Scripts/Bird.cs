using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject Feathers;
    public GameObject FeatherExplosion;
    public AudioSource Slingshot;
    public AudioSource SlingshotRelease;
    public AudioSource Flying;
    public AudioSource BirdCollision;
    public float ReleaseTime = 0.5f;
    public float DestructionTime = 5f;
    private bool _isPressed;
    private bool _isFired;

    void FixedUpdate()
    {
        if (_isPressed && !_isFired && !GameManager.Instance.IsLevelCleared)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 6.5f));
            if (worldPosition.y >= 0.2f && worldPosition.y <= 8f)
            {
                Rb.position = worldPosition;
            }
        }
    }

    void OnMouseDown()
    {
        if (_isFired || GameManager.Instance.IsLevelCleared)
        {
            return;
        }

        _isPressed = true;
        Rb.isKinematic = true;
        Slingshot.Play();
    }

    void OnMouseUp()
    {
        if (_isFired || GameManager.Instance.IsLevelCleared)
        {
            return;
        }

        _isPressed = false;
        Rb.isKinematic = false;

        GameManager.Instance.ActiveTurn = true;

        GetComponent<TrailRenderer>().enabled = true;
        _isFired = true;
        SlingshotRelease.Play();
        Flying.Play();
        StartCoroutine(Release());
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<TrailRenderer>().enabled = false;
        if (!collision.collider.CompareTag("Ground"))
        {
            GameObject feathers = Instantiate(Feathers, transform.position, Quaternion.identity);
            Destroy(feathers, 2);
            if (!BirdCollision.isPlaying)
            {
                BirdCollision.Play();
            }
            GameManager.Instance.AddScore(Random.Range(5, 25) * 10, transform.position, Color.white);
        }
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(ReleaseTime);

        Destroy(GetComponent<SpringJoint>());
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(DestructionTime);

        GameManager.Instance.SetNewBird();
        GameManager.Instance.BirdDestroy.Play();
        Instantiate(FeatherExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
