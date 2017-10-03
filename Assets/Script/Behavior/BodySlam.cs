using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySlam : MonoBehaviour {

    public float _accelSpeed = 0.001f;

    private float _maxSpeed = 3;
    private float _speed = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * _speed);

        if (_speed < _maxSpeed)
        {
            _speed += _accelSpeed * Time.deltaTime;
        }
    }
}
