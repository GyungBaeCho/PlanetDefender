using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStatus : MonoBehaviour
{
    private bool _death = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDeath(bool death)
    {
        _death = death;
    }

    public bool IsDead()
    {
        return _death;
    }
}
