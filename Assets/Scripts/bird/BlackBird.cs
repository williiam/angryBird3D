using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : BaseBird
{
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 500;
    [SerializeField] private GameObject _particles;

    private void Awake()
    {
        birdType = "black";
    } 

    public override void CastSpell(){
        
        // 使此鳥快速放大後縮小
        //this.transform.localScale = new Vector3(15f, 15f, 15f);

        Debug.Log("BlackBird CastSpell");
        updateIsCastSpell();
        var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (var obj in surroundingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;

            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, 1);
        }
        Instantiate(_particles, transform.position, Quaternion.identity);
        this.transform.localScale = new Vector3(1f, 1f, 1f);
        ParticleSystem Explosion = GetComponent<ParticleSystem>();
        this.transform.localScale = new Vector3(0f, 0f, 0f);
        Explosion.Play();
    }

    // onClick
    // 點擊後，使在彈弓上生成一隻當前種類的待射鳥
    private void OnMouseDown()
    {
        var bird = BirdManager.Instance.GetCurrentBird();
        if(bird!=null&&bird.GetType()== typeof(BlackBird)){
            return;
        }
        BirdManager.Instance.SetCurrentBird("black");
    }
}
