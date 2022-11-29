using UnityEngine;

public class Pig : MonoBehaviour
{
    public GameObject Smoke;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5f)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        GameManager.Instance.PigHit.Play();
        GameManager.Instance.PigDestroy.Play();
        GameObject smoke = Instantiate(Smoke, transform.position, Quaternion.identity);
        GameManager.Instance.AddScore(5000, transform.position, Color.green);
        Destroy(smoke, 3);
        Destroy(gameObject);
    }
}