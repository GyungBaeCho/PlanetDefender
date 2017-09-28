using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour {
    public Joystick     _joystick;
    public SteerHelm    _steerHelm;
    public float        _moveSpeed;

    private float       _fDegree;
    private Vector3     _moveVector;
    private Transform   _transform;

    // Use this for initialization
    void Start () {
        _fDegree = 0;
        _transform = transform;
        _moveVector = Vector3.zero;
    }

	// Update is called once per frame
	void Update () {
        _fDegree = _steerHelm.GetDegree();
        transform.Rotate(0, 0, _fDegree);

        float h = _joystick.GetHorizontalValue();
        float v = _joystick.GetVerticalValue();
        _moveVector = new Vector3(h, v, 0);

        if (_moveVector.magnitude > 1)
        {
            _moveVector = _moveVector.normalized;
        }

        Move();
    }

    public void Move()
    {
     //   transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
        transform.position += _moveVector * _moveSpeed * Time.deltaTime;
    }
}
