using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpStatus : MonoBehaviour {
    public float    _maxHp = 0;
    public float    _recoverHp = 0;

    private float   _hp = 0;

	// Use this for initialization
	void Start () {
        _hp = _maxHp;

    }
	
	// Update is called once per frame
	void Update ()
    {
        _hp += _recoverHp * Time.deltaTime;
        Verify();
	}

    private void Verify()
    {
        if (_hp < 0)
        {
            _hp = 0;
        }
        else if (_hp > _maxHp) {
            _hp = _maxHp;
        }
    }

    public void AddHp(float hp)
    {
        _hp += hp;
        Verify();
    }

    public float GetHp()
    {
        return _hp;
    }
}
