using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private GameObject _particles;
 
    private void OnCollisionEnter(Collision collision) {
        if (collision.relativeVelocity.magnitude > 3f) {
            GameManagerV2.Instance.AddScore(2000);
            if (collision.relativeVelocity.magnitude >= _triggerForce) {
                var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);
    
                foreach (var obj in surroundingObjects) {
                    var rb = obj.GetComponent<Rigidbody>();
                    if (rb == null) continue;
    
                    rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius,1);
                }
    
                Instantiate(_particles, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
