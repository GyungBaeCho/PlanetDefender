using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatus : MonoBehaviour {

    public GameObject _tower = null;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (_tower)
        {
            ProjectileShooter projectileShooter = _tower.GetComponent<ProjectileShooter>();
            GameObject projectile = projectileShooter._bulletPrefab;

            DamageStatus damageStatus = projectile.GetComponent<DamageStatus>();

            //GameObject radar = projectile.transform.Find("RadarCollider").gameObject;
            //radar.SetActive(false);

            Text text = transform.Find("Text_FireRate").GetComponent<Text>();
            text.text = projectileShooter.GetFireRate();

            text = transform.Find("Text_Damage").GetComponent<Text>();
            text.text = damageStatus.GetInfo();

            text = transform.Find("Text_Speed").GetComponent<Text>();
        }
	}
}
