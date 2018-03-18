using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStatus : MonoBehaviour
{
    public float    _rand = 0;
    public float    _damage = 0;

    // Use this for initialization
    void Start()
    {
        if (_damage < _rand)
        {
            print("damage보다 rand 값이 더 큽니다");
            _rand = _damage;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Verify()
    {
        if (_damage < 0)
        {
            _damage = 0;
        }
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
        Verify();
    }

    public float GetDamage()
    {
        //_rand 값을 통해 +-a 값의 데미지를 반환한다.
        return Random.Range(_damage-_rand, _damage+_rand);
    }

    public string GetInfo()
    {
        string info = "Damage : " + _damage + " ± " + _rand;
        return info;
    }
}
