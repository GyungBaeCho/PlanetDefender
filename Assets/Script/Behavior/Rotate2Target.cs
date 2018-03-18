using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2Target : MonoBehaviour {
    public float        _maxRotatingPower = 0;

    private GameObject  _targetObject = null;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        //Vector3 scale = transform.localScale;
        //print(scale);
        //scale.x /= transform.root.localScale.x;
        //scale.y /= transform.root.localScale.y;
        //scale.z /= transform.root.localScale.z;
        //transform.localScale = scale;
        Homing();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (_targetObject)
        {
            return;
        }

        switch (target.gameObject.tag)
        {
            case "Enemy":
                _targetObject = target.gameObject;
                break;
        }
    }

    void Homing()
    {
        if (_targetObject)
        {
            Vector2 vCenter = transform.position;
            Vector2 vMove = new Vector2(transform.up.x, transform.up.y).normalized;
            Vector2 vTarget = (new Vector2(_targetObject.transform.position.x, _targetObject.transform.position.y) - vCenter).normalized;

            //두 벡터 사이각도를 구하기 위함
            float fDot = Vector2.Dot(vMove, vTarget);
            float fDegree = Mathf.Acos(fDot) * Mathf.Rad2Deg;

            //외적을 통한 Z값 추출(회전 방향)
            if (((vMove.x * vTarget.y) - (vMove.y * vTarget.x)) < 0)
            {
                fDegree = -fDegree;
            }

            if (fDegree < 0)
            {
                fDegree = Mathf.Max(fDegree, -_maxRotatingPower) * 10;
            }
            else
            {
                fDegree = Mathf.Min(fDegree, _maxRotatingPower) * 10;
            }

            transform.root.Rotate(0, 0, fDegree * Time.deltaTime);
        }
    }
}
