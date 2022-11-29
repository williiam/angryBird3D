using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject IceShatter;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 8)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        GameObject shatter = Instantiate(IceShatter, transform.position, Quaternion.identity);
        GameManager.Instance.AddScore(500, transform.position, Color.white);
        GameManager.Instance.IceDestruction.Play();
        Destroy(shatter, 2);
        Destroy(gameObject);
    }
}
