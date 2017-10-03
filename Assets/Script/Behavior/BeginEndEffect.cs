using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

public class BeginEndEffect : MonoBehaviour
{
    public GameObject[] _beginPerfabs;
    public GameObject[] _endPerfabs;
    public int          _deleteDelay;

    // Use this for initialization
    void Start ()
    {
        foreach (GameObject pvtParticle in _beginPerfabs)
        {
            Destroy((GameObject)Instantiate(pvtParticle, transform.position, transform.rotation), _deleteDelay);
        }
    }

    //파티클 발생 없이 소멸되어야 하는 경우에도 호출된다.
    void OnDestroy()
    {
        if (GlobalVariable.IsInZone(transform.position))
        {
            return;
        }

        foreach (GameObject pvtParticle in _endPerfabs)
        {
            Destroy((GameObject)Instantiate(pvtParticle, transform.position, transform.rotation), _deleteDelay);
        }
    }

    //void EmitParticle()
    //{
    //    foreach (GameObject pvtParticle in _endPerfabs)
    //    {
    //        Destroy((GameObject)Instantiate(pvtParticle, transform.position, transform.rotation), _deleteDelay);
    //    }
    //}
}
