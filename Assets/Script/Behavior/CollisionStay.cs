﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStay : MonoBehaviour
{
    private GameObject _rootObject = null;

    // Use this for initialization
    void Start()
    {
        _rootObject = transform.root.gameObject;
        //GameObject coll = Instantiate(_collisionPrefab, transform);
    }

    private void OnTriggerStay2D(Collider2D target)
    {
        switch (target.gameObject.tag)
        {
            case "Enemy":
                //_rootObject.SendMessage("EmitParticle");
                //_rootObject.SendMessage("Destroy");
                break;
        }
    }
}
