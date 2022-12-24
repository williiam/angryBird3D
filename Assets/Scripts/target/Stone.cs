using UnityEngine;

public class Stone : MonoBehaviour
{
    public AudioSource StoneCollision;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bird"))
        {
            StoneCollision.Play();
        }
    }
}
