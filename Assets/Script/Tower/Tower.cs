﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private List<GameObject>    _lstBullet;
    private float               _fireTimer;

    public float                _fireRate;
    public GameObject           _bulletPrefab;

    // Use this for initialization
    void Start () {
        _lstBullet = new List<GameObject>();
        _fireTimer = Random.Range(0, 1.0f /_fireRate);
    }
	
	// Update is called once per frame
	void Update ()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer > 1/_fireRate)
        {
           GameObject newBullet = (GameObject)Instantiate(_bulletPrefab, transform.position, transform.rotation);
           _lstBullet.Add(newBullet);

//          fireTimer -= fireRate;
            _fireTimer = 0;
        }

        for (int i = 0; i < _lstBullet.Count; ++i)
        {
            GameObject pvtBullet = _lstBullet[i];
            if (pvtBullet != null)
            {
                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(pvtBullet.transform.position);

                float plusAlpha = 100;
                if (Screen.width + plusAlpha <= bulletScreenPos.x || bulletScreenPos.x <= -plusAlpha || Screen.height + plusAlpha <= bulletScreenPos.y || bulletScreenPos.y <= -plusAlpha)
                {
                    pvtBullet.GetComponent<Projectile>().Destroy();
                    Destroy(pvtBullet);
                    _lstBullet.Remove(pvtBullet);
                }
            }
        }
    }
}
