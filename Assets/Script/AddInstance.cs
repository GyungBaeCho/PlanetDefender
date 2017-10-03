using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInstance : MonoBehaviour {
    public GameObject[] _collisionPerfabs;

    // Use this for initialization
    void Start()
    {
        foreach (GameObject pvtParticle in _collisionPerfabs)
        {
            Instantiate(pvtParticle, transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
