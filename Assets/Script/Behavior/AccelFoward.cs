using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelFoward : MonoBehaviour
{
    public float    _accelSpeed = 0;
    public float    _launchSpeed = 0;
    public float    _launchDecrease = 0;
    public float    _boostBegin = 0;

    private float   _speed = 0;
    private bool    _boosterOn = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_boosterOn)
        {
            //파티클 시스템 위치 이동 & Offset(로켓 분출구에 위치하도록)
            transform.Translate(new Vector3(0, 1, 0) * _speed * Time.deltaTime);
            _speed += _accelSpeed * Time.deltaTime;
            _accelSpeed += _accelSpeed * Time.deltaTime;
        }
        else
        {
            transform.Translate(new Vector3(0, 1, 0) * _launchSpeed * Time.deltaTime);
            _launchSpeed -= _launchDecrease * Time.deltaTime;

            if (_launchSpeed < _boostBegin)
            {
                _boosterOn = true;
                _speed = _launchSpeed;
             //   _tailParticle = (GameObject)Instantiate(_tailParticlePrefab, transform.position, transform.rotation);
            }
        }
    }
}
