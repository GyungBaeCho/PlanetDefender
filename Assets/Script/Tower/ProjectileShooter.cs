using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ProjectileShooter : MonoBehaviour
{
    private float               _fireTimer;

    public float                _fireRate;
    public GameObject           _bulletPrefab;

    // Use this for initialization
    void Start () {
        _fireTimer = Random.Range(0, 1.0f /_fireRate);
    }
	
	// Update is called once per frame
	void Update ()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer > 1/_fireRate)
        {
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
            //fireTimer -= fireRate;
            _fireTimer = 0;
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        print("zzzz");
        //터치시 UI Alpha 최대 불투명
    }

    public string GetFireRate()
    {
        string info = "Fire Rate : " + _fireRate.ToString() + " per sec";
        return info;
    }
}
