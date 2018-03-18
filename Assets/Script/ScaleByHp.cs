using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleByHp : MonoBehaviour
{
    private Vector3 _initScale;

	// Use this for initialization
	void Start () {
        _initScale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        HpStatus hpStatus = transform.root.gameObject.GetComponent<HpStatus>();
        float fPercentage = hpStatus.GetPerecentage();

        transform.localScale = new Vector3(fPercentage * _initScale.x, _initScale.y, _initScale.z);
	}
}
