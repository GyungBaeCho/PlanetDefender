using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailEmission : MonoBehaviour
{
    public GameObject[]         _particlePerfabs;
    public int                  _deleteDelay = 0;
    public float                _startDelay = 0;

    private List<GameObject>    _particles;

    // Use this for initialization
    void Start()
    {
        _particles = new List<GameObject>();
        EmitParticle();
    }

    private void EmitParticle()
    {
        foreach (GameObject pvtParticle in _particlePerfabs)
        {
            GameObject newParticle = Instantiate(pvtParticle, transform);
            newParticle.GetComponent<ParticleSystem>().startDelay = _startDelay;
            _particles.Add(newParticle);
            //_particles.Add((GameObject)Instantiate(pvtParticle, transform.position, transform.rotation));
        }
    }

//    private void Update()
//    {
//        foreach (GameObject pvtParticle in _particles)
//        {
//            //pvtParticle.transform.parent = null;
//            pvtParticle.transform.parent = transform.root;
////            pvtParticle.transform.position = transform.root.position;
//////            pvtParticle.transform.parent = null;
//        }
//    }

    public void DestroyTail()
    {
        foreach (GameObject pvtParticle in _particles)
        {
            pvtParticle.transform.parent = null;
            pvtParticle.GetComponent<ParticleSystem>().Stop();
            Destroy(pvtParticle, _deleteDelay);
        }
    }

    //private void Destroy()
    //{
    //    foreach (GameObject pvtParticle in _particles)
    //    {
    //        pvtParticle.GetComponent<ParticleSystem>().Stop();
    //        Destroy(pvtParticle, _deleteDelay);
    //    }
    //}
}
