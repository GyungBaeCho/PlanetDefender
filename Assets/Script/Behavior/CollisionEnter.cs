using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour
{
    //public GameObject _collisionPrefab = null;

    private GameObject _rootObject = null;

    // Use this for initialization
    void Start () {
        _rootObject = transform.root.gameObject;
//        GameObject coll = Instantiate(_collisionPrefab, transform);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //}

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(center.x, center.y), radius);
        foreach (Collider2D collider2D in hitColliders)
        {
            //HpStatus status = collider2D.GetComponent<HpStatus>();

            //status = collider2D.transform.root.gameObject.GetComponent<HpStatus>();

            //collider2D.gameObject.layer;
            if (collider2D.gameObject.tag == "Enemy")
            {
                collider2D.transform.root.SendMessage("AddHp", -50);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        switch (target.gameObject.tag)
        {
            case "Enemy":
                ExplosionDamage(transform.position, 10);
                //_rootObject.SendMessage("EmitParticle");
                _rootObject.SendMessage("Destroy");
                //target.gameObject.SendMessage("AddHp", -100);
                break;
        }
    }
}
