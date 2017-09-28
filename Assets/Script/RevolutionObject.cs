using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionObject : MonoBehaviour {
    public MonoBehaviour        _Planet;
    public GameObject           _projectilePrefab;

    private List<GameObject>    _projectiles = new List<GameObject>();
    private float               _projectileSpeed;
    private float               _fireRate;
    private float               _fireTimer;

    // Use this for initialization
    void Start () {
        _projectileSpeed = 2000;
        _fireRate = 1/10.0f;
        _fireTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown("jump"))
        //{

        //}

        _fireTimer += Time.deltaTime;
        if (_fireTimer > _fireRate)
        {
            GameObject bullet = (GameObject)Instantiate(_projectilePrefab, transform.position, transform.rotation);
            _projectiles.Add(bullet);
            _fireTimer -= _fireRate;
        }

        for (int i = 0; i < _projectiles.Count; ++i)
        {
            GameObject pvtBullet = _projectiles[i];
            if (pvtBullet != null)
            {
                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(pvtBullet.transform.position);

                float plusAlpha = 100;
                if (Screen.width <= bulletScreenPos.x + plusAlpha || bulletScreenPos.x <= -plusAlpha || Screen.height + plusAlpha <= bulletScreenPos.y || bulletScreenPos.y <= -plusAlpha)
                {
                    DestroyObject(pvtBullet);
                    _projectiles.Remove(pvtBullet);
                }
            }
        }
    }

    public void Revolute(float fDegree)
    {
        transform.RotateAround(_Planet.transform.position, new Vector3(0, 0, 1), fDegree/10);
    }

    void Fire()
    {
    }
}
