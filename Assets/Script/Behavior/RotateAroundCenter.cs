using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCenter : MonoBehaviour {
    //Root Object의 BoxCollider 크기
    public float    _rootMagnitude = 0;

    // Use this for initialization
    void Start () {
        Collider2D rootCollider = transform.root.GetComponent<Collider2D>();

        //Collider의 종류가 BoxCollider라면
        if (rootCollider.GetType() == typeof(BoxCollider2D))
        {
            rootCollider.gameObject.GetComponentInChildren<BoxCollider2D>();

            BoxCollider2D rootBoxCollider = (BoxCollider2D)rootCollider;
            Vector2 colliderSize = rootBoxCollider.size;
            colliderSize.x *= transform.root.localScale.x;
            colliderSize.y *= transform.root.localScale.y;
            _rootMagnitude = colliderSize.magnitude;
        }
        else
        {
            _rootMagnitude = 1;
        }
    }

    //화면 중앙을 기준으로 Hp Bar를 회전시킨다
    void UpdateRotation()
    {
        transform.rotation = Quaternion.identity;

        Vector2 vCenter = Vector2.zero;
        Vector2 vNew = (new Vector2(transform.position.x, transform.position.y) - vCenter).normalized;
        Vector2 vPre = (new Vector2(0, 1) - vCenter).normalized;

        //두 벡터 사이각도를 구하기 위함
        float fDot = Vector2.Dot(vNew, vPre);
        float fDegree = Mathf.Acos(fDot) * Mathf.Rad2Deg;

        //외적을 통한 Z값 추출(회전 방향)
        if (((vNew.x * vPre.y) - (vNew.y * vPre.x)) > 0)
        {
            fDegree = -fDegree;
        }

        transform.Rotate(0, 0, fDegree);
    }

    //Root Object Position을 기준으로 이동
    private void UpdatePosition()
    {
        transform.position = transform.root.position + transform.up * _rootMagnitude;
    }

    // Update is called once per frame
    private void Update () {
        UpdateRotation();
        UpdatePosition();

        //Vector3 position = transform.root.position;
        //Vector3 up = (position - Vector3.zero).normalized;
        //Vector3 look = new Vector3(0, 0, -1);
        //Vector3 right = Vector3.Cross(look, up).normalized;

        //transform.localToWorldMatrix.SetRow(0, right);
        //transform.localToWorldMatrix.SetRow(1, up);
        //transform.localToWorldMatrix.SetRow(2, look);
    }

    private void LateUpdate()
    {

    }
}
