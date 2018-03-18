using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

public class DrawHpBar : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        GameObject newObject = Instantiate(GlobalVariable._dicPrefabs["HpBar"], transform.position, transform.rotation);
        newObject.transform.SetParent(transform, true);
        newObject.AddComponent<RotateAroundCenter>();
        newObject.AddComponent<ScaleByHp>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
