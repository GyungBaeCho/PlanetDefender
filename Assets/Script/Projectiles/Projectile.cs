using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float        _projectileSpeed;
    private Vector3     _velocity;

    ~Projectile()
    {
//        print("~Projectile");
    }

    void Start()
    {

    }

    public virtual void Destroy()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * _projectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            Destroy(transform.root.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        
    }
}
