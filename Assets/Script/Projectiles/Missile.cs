using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    //Missile Movement
    public float        _accelSpeed = 0;
    public float        _launchSpeed = 0;
    public float        _launchDecrease = 0;

    private GameObject  _tailParticle;

    //Particle Prefab
    public GameObject   _tailParticlePrefab;
    public GameObject   _flareParticlePrefab;
    public GameObject   _explodeParticletPrefab;

//    private ParticleSystem a;

    void Start()
    {

    }

    public override void Destroy() 
    {
        if (_tailParticle != null)
        {
            _tailParticle.GetComponent<ParticleSystem>().Stop();
        }
        Destroy(_tailParticle, 2);
    }

    void Update()
    {
        if (0 < _launchSpeed)
        {
            transform.Translate(new Vector3(0, 1, 0) * _launchSpeed * Time.deltaTime);
            _launchSpeed -= _launchDecrease * Time.deltaTime;

            if (_launchSpeed < 0) {
                _tailParticle = (GameObject)Instantiate(_tailParticlePrefab, transform.position, transform.rotation);
            }
        }
        else {
            _projectileSpeed += _accelSpeed * Time.deltaTime;

            //파티클 시스템 위치 이동 & Offset(로켓 분출구에 위치하도록)
            transform.Translate(new Vector3(0, 1, 0) * _projectileSpeed * Time.deltaTime);
            _tailParticle.transform.position = transform.position - (transform.up.normalized * 50);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Enemy")
        {
            //Flare를 생성하고 동시에 1초 후에 Destroy 시킵니다.
            Destroy((GameObject)Instantiate(_flareParticlePrefab, transform.position, transform.rotation), 1);
            Destroy((GameObject)Instantiate(_explodeParticletPrefab, transform.position, transform.rotation), 1);

            Destroy(transform.root.gameObject);
            Destroy();
        }
    }

}