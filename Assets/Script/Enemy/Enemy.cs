using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

public class Enemy : MonoBehaviour {
    //Status
    private HpStatus    _hpStatus;

    // Use this for initialization
    void Start () {
        _hpStatus = transform.root.gameObject.GetComponent<HpStatus>();
    }

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


    // Update is called once per frame
    void Update () {
        UpdateRotation();

        //Vector2 center = Vector2.zero;
        //Vector2 position = transform.position;
        //Vector2 direction = (position - center).normalized;
        //
        //transform.rotation = Quaternion.LookRotation(direction);
        //transform.Rotate(0, 90, 0);
        //transform.Rotate(0, 0, 90);
    }

    private void OnTriggerStay2D(Collider2D target)
    {
        switch (target.gameObject.tag)
        {
        case "Projectile":
            DamageStatus targetDamage = target.transform.parent.gameObject.GetComponent<DamageStatus>();

            if (targetDamage && _hpStatus)
            {
                _hpStatus.AddHp(-targetDamage.GetDamage());
            }

            //Enemy를 삭제합니다
            if (_hpStatus.GetHp() == 0)
            {
                Destroy(transform.gameObject);
            }
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        switch (target.gameObject.tag) {
        case "Projectile":
            //DamageStatus targetDamage = target.transform.root.gameObject.GetComponent<DamageStatus>();
            DamageStatus targetDamage = target.transform.parent.gameObject.GetComponent<DamageStatus>();

            if (targetDamage && _hpStatus)
            {
                _hpStatus.AddHp(-targetDamage.GetDamage());
            }

            //Enemy를 삭제합니다
            if (_hpStatus.GetHp() == 0)
            {
                Destroy(transform.gameObject);
            }
            break;
        case "Planet":
            _hpStatus.AddHp(-float.MaxValue);

            if (_hpStatus.GetHp() == 0)
            {
                Destroy(transform.gameObject);
            }
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        print("Collision");
    }
}
