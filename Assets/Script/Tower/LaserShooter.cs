using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    private float _fireTimer;

    public float _fireRate;
    public GameObject _bulletPrefab;

    // Use this for initialization
    void Start()
    {
        _fireTimer = Random.Range(0, 1.0f / _fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer > 1 / _fireRate)
        {
            Instantiate(_bulletPrefab, transform);
            //   _lstBullet.Add(newBullet);

            //fireTimer -= fireRate;
            _fireTimer = 0;
        }
    }
}
