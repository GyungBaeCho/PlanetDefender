using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    public float    _maxTime = 0;

    private float   _countTime = 0;

    void Start()
    {

    }

    void Update()
    {
        if (RemovalCheck())
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        TailEmission tail = GetComponent<TailEmission>();
        if (tail)
        {
            tail.DestroyTail();
        }
        Destroy(transform.gameObject);
    }


    private bool RemovalCheck()
    {
        _countTime += Time.deltaTime;

        if (_maxTime < _countTime)
        {
            return true;
        }
        return false;
    }
}
