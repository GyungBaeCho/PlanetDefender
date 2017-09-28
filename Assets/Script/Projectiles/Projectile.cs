using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float        _projectileSpeed;
    private Vector3     _velocity;

    public GameObject[] _arrDeathParticlePerfab;

    ~Projectile()
    {
//        print("~Projectile");
    }

    void Start()
    {

    }

    public virtual void Destroy()
    {
        Destroy(transform.root.gameObject);
    }

    virtual public bool RemovalCheck()
    {
        Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        float plusAlpha = 100;
        if (Screen.width + plusAlpha <= bulletScreenPos.x || bulletScreenPos.x <= -plusAlpha || Screen.height + plusAlpha <= bulletScreenPos.y || bulletScreenPos.y <= -plusAlpha)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * _projectileSpeed);
        if (RemovalCheck()){
            Destroy();
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            foreach (GameObject pvtParticle in _arrDeathParticlePerfab)
            {
                Destroy((GameObject)Instantiate(pvtParticle, transform.position, transform.rotation), 1);
            }

            Destroy();
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        
    }
}
